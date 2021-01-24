    public class XmlBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            try
            {
                var memoryStream = new MemoryStream();
                await bindingContext.HttpContext.Request.Body.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                XElement root = XElement.Load(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                string messageType = root.Element("MsgType").Value;
                Type xmlType = GetTypeFromMessage(messageType);
                var serializer = new XmlSerializer(xmlType);
                var model = serializer.Deserialize(memoryStream);
                bindingContext.Result = ModelBindingResult.Success(model);
            }
            catch
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }
        }
        private Type GetTypeFromMessage(string msgType)
        {
            switch (msgType)
            {
                case "text":
                    return typeof(TextMsg);
                case "image":
                    return typeof(ImageMsg);
                //... other cases
                default:
                    return typeof(BaseClass);
            }
        }
    }
