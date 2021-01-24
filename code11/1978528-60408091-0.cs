    public string ObjectToXML()
        {
            using(var stringwriter = new System.IO.StringWriter())
            { 
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stringwriter, this);
                return stringwriter.ToString();
            }
        }
