    internal class ParseXML 
    {
        public static xsdClass ToClass<xsdClass>(XElement ResponseXML)
        {
            return deserialize<xsdClass>(ResponseXML.ToString(SaveOptions.DisableFormatting));
        } 
        private static result deserialize<result>(string XML)
        {
            using (TextReader textReader = new StringReader(XML))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(result));
                return (result) xmlSerializer.Deserialize(textReader);
            }
        } 
    } 
