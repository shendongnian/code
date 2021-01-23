    public class XmlResult : ActionResult
    {
        private readonly object _data;
        public XmlResult(object data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            _data = data;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            // You could use any XML serializer that fits your needs
            // In this example I use XmlSerializer
            var serializer = new XmlSerializer(_data.GetType());
            var response = context.HttpContext.Response;
            response.ContentType = "text/xml";
            serializer.Serialize(response.OutputStream, _data);
        }
    }
