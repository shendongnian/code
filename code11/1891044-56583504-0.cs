    public string ToXML()
        {
            using(var stringwriter = new System.IO.StringWriter())
            { 
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stringwriter, this);
                return stringwriter.ToString();
            }
        }
    
     public static YourClass LoadFromXMLString(string xmlText)
        {
            using(var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(YourClass ));
                return serializer.Deserialize(stringReader) as YourClass ;
            }
        }
