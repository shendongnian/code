    public static class ControllerExtensions
    {
        public static ActionResult Xml(this ControllerBase controller, object model)
        {
            return new XmlResult(model);
        }
    }
