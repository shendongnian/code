        /// <summary>
        /// This method serializes objects to an XML string using the XmlSerializer
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SerializeObjectToXMLString(object theObject)
        {
            // Exceptions are handled by the caller
            using (System.IO.MemoryStream oStream = new System.IO.MemoryStream())
            {
                System.Xml.Serialization.XmlSerializer oSerializer = new System.Xml.Serialization.XmlSerializer(theObject.GetType());
                oSerializer.Serialize(oStream, theObject);
                return Encoding.Default.GetString(oStream.ToArray());
            }
        }
