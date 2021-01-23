    public class XmlResult : ActionResult
    {
        private readonly object _model;
        public XmlResult(object model)
        {
            _model = model;
        }
    
        public override void ExecuteResult(ControllerContext context)
        {
            if (_model != null)
            {
                var response = context.HttpContext.Response;
                var serializer = new XmlSerializer(_model.GetType());
                response.ContentType = "text/xml";
                serializer.Serialize(response.OutputStream, _model);
            }
        }
    }
