    public class AsyncHttpModule : IHttpModule {
        public void Dispose() { }
        public void Init(HttpApplication app) {
            var wrapper = new EventHandlerTaskAsyncHelper(DoAsyncWork);
            app.AddOnBeginRequestAsync(wrapper.BeginEventHandler, wrapper.EndEventHandler);
        }
        private async Task DoAsyncWork(object sender, EventArgs e) {
            var app = (HttpApplication) sender;
            var ctx = app.Context;
            if (shouldDie) { //whatever your criteria is
                await Task.Delay(60000); //wait for one minute
                ctx.Request.Abort(); //kill the connection without replying
            }
        }
    }
