    [RunInstaller(true)]
    public class MyInstaller: Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            // add here the code that checks if the user is correct by opening
            // a Login form
            base.Install(stateSaver);
        }
    
        // Other override methods here if necessary
    }
