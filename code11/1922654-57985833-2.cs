    public class MyControllerBase: Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var bodyStr = "";
            var req = context.HttpContext.Request;
            // Allows using several time the stream in ASP.Net Core
            req.EnableRewind();
            // Arguments: Stream, Encoding, detect encoding, buffer size 
            // AND, the most important: keep stream opened
            using (StreamReader reader
                    = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = reader.ReadToEnd();
            }
            // Rewind, so the core is not lost when it looks the body for the request
            req.Body.Position = 0;
        }
    }
