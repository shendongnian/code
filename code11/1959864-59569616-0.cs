    public class RawBodyAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var request = context.HttpContext.Request;
            request.EnableBuffering(); // you cannot seek original request stream
            // make sure stream is not disposed
            using (var reader = new StreamReader(request.Body, leaveOpen: true))
            {
                var body = reader.ReadToEnd();
                // simplest way to pass body value to controller
                context.HttpContext.Items.Add("Body", body);
                request.Body.Position = 0; // now model binder can read stream again
            }
        }
    }
