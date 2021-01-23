    [Export(typeof(IMainApp))]
    public class Host : IMainApp
    {
        public Host()
        { /* Compose parts etc here..? */ }
    
        public ConfigClass Config { get; set; }  
    
        [Import(typeof(IModule))]
        public List<IModule> LoadedModules { get; set; }
    }
