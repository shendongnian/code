    string path = string.Empty;
                string xmlInputData = string.Empty;
                try
                {
                   path = "XML file path";
                    xmlInputData = File.ReadAllText(path);
                    Messages _Messages = Deserialize<Messages>(xmlInputData);
                }
                catch (Exception ex)
                {
                    throw;
                }
                    
            }
            public static T Deserialize<T>(string input) where T : class
            {
                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
    
                using (StringReader sr = new StringReader(input))
                {
                    return (T)ser.Deserialize(sr);
                }
            }
