    public class XmlCreationConverter : XmlSerializerInputFormatter
    {
        private readonly MvcOptions _options;
        public XmlCreationConverter(MvcOptions options) : base(options)
        {
            _options = options;
        }
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
           InputFormatterContext context,
           Encoding encoding)
        {
            XElement xml = null;
            Type type = typeof(BaseClass);
            var request = context.HttpContext.Request;
            context.HttpContext.Request.EnableBuffering();
           
            using (StreamReader reader = new StreamReader(request.Body))
            {
                var text = await reader.ReadToEndAsync();
               
                request.Body.Position = 0; 
                xml = XElement.Parse(text);
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
