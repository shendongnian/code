    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (ForceSoftwareRendering)
                RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
        }
    }
