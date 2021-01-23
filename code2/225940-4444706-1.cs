    [Export(typeof(IModule))]
    public class Module : IModule
    {        
        public Module() { }
    
        [Import(typeof(IMainApp))]
        public IMainApp Host { get; set; } 
    
        public void DoSomething()
        {
            Host.Config... // use config here
        }
    }
