    public class JsonModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (!IsJSONRequest(controllerContext))
                return base.BindModel(controllerContext, bindingContext);
            // Get the JSON data that's been posted
            var jsonStringData = new StreamReader(controllerContext.HttpContext.Request.InputStream).ReadToEnd();
            // Wrap numerics
            jsonStringData = Regex.Replace(jsonStringData, "(?<=:)\\s*(?<num>[\\d\\.]+)\\s*(?=[,|\\[|\\]|\\{|\\}]+)", "\"${num}\"");
            // Use the built-in serializer to do the work for us
            return new JavaScriptSerializer().Deserialize(jsonStringData, bindingContext.ModelMetadata.ModelType);
        }
        private static bool IsJSONRequest(ControllerContext controllerContext)
        {
            var contentType = controllerContext.HttpContext.Request.ContentType;
            return contentType.Contains("application/json");
        }
    }
