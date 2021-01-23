    [RunInstaller(true)]
    public partial class CustomInstaller : System.Configuration.Install.Installer
    {
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            string path = this.Context.Parameters["targetdir"]; 
            // Do something with path.
        } 
    }
