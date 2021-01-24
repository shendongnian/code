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
           //for model type is Baseclass
           if (context.ModelType == typeof(BaseClass))
            {
                using (StreamReader reader = new StreamReader(request.Body))
                {
                    var text = await reader.ReadToEndAsync();
                    request.Body.Position = 0;
                    xml = XElement.Parse(text);
                    if (xml.Element("MsgType").Value == "text")
                    {
                        type = typeof(TextMsg);
                    }
                    using (XmlReader xmlReader = CreateXmlReader(request.Body, encoding))
                    {
                        var serializer = GetCachedSerializer(type);
                        var deserializedObject = serializer.Deserialize(xmlReader);
                        return InputFormatterResult.Success(deserializedObject);
                    }
                }
            }
            else if(context.ModelType == ...)
            else
            {
                using (StreamReader reader = new StreamReader(request.Body))
                {
                    var text = await reader.ReadToEndAsync();
                    request.Body.Position = 0;
                    using (var xmlReader = CreateXmlReader(request.Body, encoding))
                    {
                        var modelType = GetSerializableType(context.ModelType);
                        var serializer = GetCachedSerializer(modelType);
                        var deserializedObject = serializer.Deserialize(xmlReader);
                        // Unwrap only if the original type was wrapped.
                        if (type != context.ModelType)
                        {
                            if (deserializedObject is IUnwrappable unwrappable)
                            {
                                deserializedObject = unwrappable.Unwrap(declaredType: context.ModelType);
                            }
                        }
                        return InputFormatterResult.Success(deserializedObject);
                    }
                }
            }
            
        }
    }
