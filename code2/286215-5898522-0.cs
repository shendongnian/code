    [RunInstaller(true)]
    public class MyInstaller: Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }
    
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            //TODO: Code to kill the live instance(s)
        }
        // Other override methods here if necessary
    }
