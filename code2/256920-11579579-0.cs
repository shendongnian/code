    public class ExpandoJsonResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            response.ContentEncoding = ContentEncoding ?? response.ContentEncoding;
            if (Data != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new JavaScriptConverter[] { new ExpandoConverter() });
                response.Write(serializer.Serialize(Data));
            }
        }
    }
