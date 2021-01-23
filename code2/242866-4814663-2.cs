    public static class ControllersExtension
    {
        public static ActionResult Xml(this ControllerBase controller, object data)
        {
            return new XmlResult(data);
        }
    }
