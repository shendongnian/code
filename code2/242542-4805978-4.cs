    public class OverrideRenderModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += this.HandlePreRequestExecute;
        }
        private void HandlePreRequestExecute(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            IOverrideRender overridable = app.Context.CurrentHandler as IOverrideRender;
            if(overridable != null)
            {
                overridable.Register(
                    (writer, original) => {
                        writer.Write("Hello world"); //custom write
                        original(writer); //calls base.Render
                });
            }
        }
    }
