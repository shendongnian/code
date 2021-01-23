    [XmlRoot("root")]
    public class Root : IXmlSerializable
    {
        [XmlElement("creatures")]
        public Creatures Items { get; set; }
    
        /// <summary>
        /// This method is reserved and should not be used. When implementing
        /// the IXmlSerializable interface, you should return null (Nothing in
        /// Visual Basic) from this method, and instead, if specifying a custom
        /// schema is required, apply the
        /// <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/>
        /// to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the
        /// XML representation of the object that is produced by the
        /// <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/>
        /// method and consumed by the
        /// <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/>
        /// method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }
    
        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream
        /// from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("root");
            reader.ReadStartElement("creatures");
    
            List<Creature> creatures = new List<Creature>();
    
            while ((reader.NodeType == XmlNodeType.Element)
                && (reader.Name == "creature"))
            {
                Creature creature;
                string type = reader.GetAttribute("type");
                string name = reader.GetAttribute("name");
    
                reader.ReadStartElement("creature");
    
                switch (type)
                {
                    case "mammal":
                        MammalCreature mammalCreature = new MammalCreature();
    
                        reader.ReadStartElement("sound");
                        mammalCreature.Sound = reader.ReadContentAsString();
                        reader.ReadEndElement();
                        creature = mammalCreature;
                        break;
                    case "bird":
                        BirdCreature birdCreature = new BirdCreature();
    
                        reader.ReadStartElement("color");
                        birdCreature.Color = reader.ReadContentAsString();
                        reader.ReadEndElement();
                        creature = birdCreature;
                        break;
                    default:
                        reader.Skip();
                        creature = new Creature();
                        break;
                }
    
                reader.ReadEndElement();
                creature.Name = name;
                creature.Type = type;
                creatures.Add(creature);
            }
    
            reader.ReadEndElement();
            this.Items = new Creatures();
            this.Items.Creature = creatures.ToArray();
            reader.ReadEndElement();
        }
    
        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream
        /// to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            new XmlSerializer(typeof(Creatures)).Serialize(writer, this.Items);
        }
    }
    
    [XmlRoot("creatures")]
    public class Creatures
    {
        [XmlElement("creature")]
        public Creature[] Creature { get; set; }
    }
    
    [XmlInclude(typeof(MammalCreature))]
    [XmlInclude(typeof(BirdCreature))]
    public class Creature
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
    
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
    
    public class MammalCreature : Creature
    {
        [XmlElement("sound")]
        public string Sound { get; set; }
    }
    
    public class BirdCreature : Creature
    {
        [XmlElement("color")]
        public string Color { get; set; }
    }
