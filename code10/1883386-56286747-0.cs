        public class RequestBodyFilter : IResourceFilter
        {
            public void OnResourceExecuted(ResourceExecutedContext context)
            {
                //throw new NotImplementedException();
            }
            public void OnResourceExecuting(ResourceExecutingContext context)
            {
                var request = context.HttpContext.Request;
                request.EnableRewind();
                request.Body.Position = 0;
                using (var reader = new StreamReader(request.Body))
                {
                    var decriptedFromJavascript = "{ \"Urno\":\"URN123456\"}"; //{ "Urno":"URN123456"}
                    byte[] bytes = Encoding.ASCII.GetBytes(decriptedFromJavascript);
                    request.Body = new MemoryStream(bytes); // here i am trying to change request body
                }
            }
        }
