    [Obsolete]
    public class XmlCreationConverter: XmlSerializerInputFormatter
    {    
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
           InputFormatterContext context,
           Encoding encoding)
        {
            XElement xml = null;
            Type type = typeof(BaseClass);
            var request = context.HttpContext.Request;
            context.HttpContext.Request.EnableRewind();
            using (StreamReader reader = new StreamReader(request.Body))
            {
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                string text = reader.ReadToEnd();
                request.Body.Position = 0; // rewind
                xml = XElement.Parse(text);
                //your logic to return the right type
                if (xml.Element("MsgType").Value == "text")
                {
                    type = typeof(TextMsg);
                }
                else if(...)
                {
                    type = ...
                }
                else
                {
                }
                using (XmlReader xmlReader = CreateXmlReader(request.Body, encoding))
                {
                    var serializer = GetCachedSerializer(type);
                    var deserializedObject = serializer.Deserialize(xmlReader);
                    return InputFormatterResult.Success(deserializedObject);
                }
            }
        }
    }
