    class APPLICATION
    {
        public APPLICATION()
        {
            this.Classes = new List<CLASS>();
            this.Cars = new List<CARS>();
            this.Items = new List<ITEM>();
            this.Pops = new List<POP>();
        }
    
        public List<CLASS> Classes { get; set; }
    
        public List<CARS> Cars { get; set; }
    
        public List<ITEM> Items { get; set; }
    
        public List<POP> Pops { get; set; }
    
        public override string ToString()
        {
            string toString = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.Indentation = 5;
                    writer.WriteStartDocument();
                        writer.WriteStartElement("APPLICATION");
                            writer.WriteStartElement("AC");
                            if (this.Classes != null && Classes.Count > 0)
                            {
                                foreach (CLASS c in Classes)
                                {
                                    writer.WriteStartElement("CLASS");
                                        writer.WriteAttributeString("Name", c.Name);
                                        writer.WriteAttributeString("Capt", c.Capt);
                                    writer.WriteEndElement(); //CLASS
                                }
                            }
                            writer.WriteEndElement(); //AC
    
                            if (this.Cars != null && Cars.Count > 0)
                            {
                                foreach (CARS c in Cars)
                                {
                                    writer.WriteStartElement("CARS");
                                        writer.WriteAttributeString("Wheel", c.Wheel);
                                        writer.WriteAttributeString("Default", c.Default);
                                    writer.WriteEndElement(); //CARS
                                }
                            }
    
                            writer.WriteStartElement("BO");
                            if (this.Items != null && Items.Count > 0)
                            {
                                foreach (ITEM c in Items)
                                {
                                    writer.WriteStartElement("ITEM");
                                        writer.WriteAttributeString("Id", c.Id);
                                        writer.WriteAttributeString("DefaultValue", c.DefaultValue);
                                        if (c.Reason != null)
                                        {
                                            writer.WriteStartElement("VAL");
                                                writer.WriteStartElement("REASON");
                                                    writer.WriteAttributeString("Id", c.Reason.Id);
                                                    writer.WriteAttributeString("SecondOne", c.Reason.SecondOne);
                                                writer.WriteEndElement(); //ITEM
                                            writer.WriteEndElement(); //VAL
                                        }
                                    writer.WriteEndElement(); //ITEM
                                }
                            }
                            writer.WriteEndElement(); //BO
                        writer.WriteEndElement(); //APPLICATION
                    writer.WriteEndDocument();
    
                    writer.Flush();
                    stream.Position = 0;
    
                    XmlTextReader reader = new XmlTextReader(stream);
    
                    reader.MoveToContent();
                    toString = reader.ReadOuterXml();
    
                    writer.Close();
                    stream.Close();
                }
            }
    
            return toString;
        }
    }
    
    public class REASON
    {
        public REASON()
        {
            Id = string.Empty;
            SecondOne = string.Empty;
        }
    
        public string Id { get; set; }
        public string SecondOne { get; set; }
    }
    
    public class ITEM
    {
        public ITEM()
        {
            Id = string.Empty;
            DefaultValue = string.Empty;
        }
    
        public string Id { get; set; }
        public string DefaultValue { get; set; }
        public REASON Reason { get; set; }
    }
    
    public class CARS
    {
        public CARS()
        {
            Wheel = string.Empty;
            Default = string.Empty;
        }
    
        public string Wheel { get; set; }
        public string Default { get; set; }
    }
    
    public class CLASS
    {
        public CLASS()
        {
            Name = string.Empty;
            Capt = string.Empty;
        }
    
        public string Name { get; set; }
        public string Capt { get; set; }
    }
    
    public class POP
    {
        public POP()
        {
            Id = string.Empty;
            Value = string.Empty;
        }
    
        public string Id { get; set; }
        public string Value { get; set; }
    }
