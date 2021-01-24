    public Person : IXmlSerializable
    {
        private string[] _myList {get; set;} = new string[3];
        public string Occupation
        {
            get { return _myList[2]; }
            set {_myList[2] = value; }
        }
        XmlSchema IXmlSerializable.GetSchema() => null;
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
             //THIS IS THE KEY LINE:
             _myList = new string[3];// you can do any initialization you need before actually reading.
            while(reader.Read())
            {
                if(reader.NodeType != XmlNoteType.Element)
                    continue;
   
                string propertyName = reader.Name; // we have arrived at an element.
                reader.Read(); // we have the property name, now get it's value
                switch(propertyName)
                {
                    case nameof(Occupation):
                        Occupation = reader.Value; // for an int, you could do: int.Parse(reader.Value);
                        break;
                }
            }
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
             writer.WriteElementString(nameof(Occupation), Occupation.ToString());
        }
    }
