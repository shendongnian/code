    using Microsoft.VisualStudio.TextTemplating;
    class UserPluginWorkflowComponent : ICallbackInterface
    {
        public void CallbackFxn()
        {
            // invoked by user plugin
        }
        public void ExecuteUserPlugin()
        {
            MyCustomHost host = new MyCustomHost(this);
            host.TemplateFileValue = "UserPluginTemplateFilename";
            Engine engine = new Engine();
            string pluginResult = engine.ProcessTemplate(
                userPluginTemplateFileContents, 
                host);            
            if (!host.Errors.HasErrors)
            {
                // use pluginResult in some meaningful way
            }
        }
    }
