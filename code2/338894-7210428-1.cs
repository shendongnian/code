    public class RestResult<T> : ActionResult
    {
        public T Data { get; set; }
        public RestResult(T data)
        {
            Data = data;
        }
        
        private string SerializeToJson()
        {
            MemoryStream ms = new MemoryStream();
            YourFavouriteJsonSerializer.SerializeToStream(Data, Data.GetType(), ms);
            var temp = Encoding.UTF8.GetString(ms.ToArray());
            return temp;
        }     
        
        public override void ExecuteResult(ControllerContext context)
        {
            string resultString = string.Empty;
            string resultContentType = string.Empty;
            // alternatively, use the route value dictionary
            // or the accept-type, as suggested.
            var extension = SomeExtensionParserMethod(context.RequestContext.HttpContext.Request.RawUrl);
            string result = string.Empty;
            if (extension == "json")
            {
            	result = SerializeJson()
            }
            else if(...)
            // etc
            
						context.RequestContext.HttpContext.Response.Write(resultString);
            context.RequestContext.HttpContext.Response.ContentType = resultContentType;
        }
    }
    
