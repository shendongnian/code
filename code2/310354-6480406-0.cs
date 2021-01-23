    public void SerializeToXml(Video video, string outputXmlFilePath)
    {
     
                if (video== null)
                {
                    throw new ArgumentNullException("@video");
                }
    
                if (outputXmlFilePath == null)
                {
                    throw new ArgumentNullException("outputXmlFilePath");
                }
    
                System.Xml.Serialization.XmlSerializer xmlSerializer =
                    new System.Xml.Serialization.XmlSerializer(video.GetType());
    
                using (StreamWriter streamWriter = new StreamWriter(outputXmlFilePath, false, Encoding.UTF8))
                {
                    xmlSerializer.Serialize(streamWriter, value);
                }
    
    }
