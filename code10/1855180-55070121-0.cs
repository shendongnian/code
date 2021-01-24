    public class TestHandler : HttpTaskAsyncHandler
    {
        public async override Task ProcessRequestAsync(HttpContext context)
        {
            var text = "walk";
            Authentication auth = new Authentication("subscriptionID");
            context.Response.Write(await auth.getVoice(text)); //added await here
        }
    //..
    }
