    using System.Runtime.CompilerServices;
    private void RestartMyApp([CallerMemberName] string callerName = "")
    {
        Application.Current.Exit += (s, e) =>
        {
            const string allowedCallingMethod = "ButtonBase_OnClick"; // todo: Set your calling method here
                
            if (callerName == allowedCallingMethod)
            {
                Process.Start(Application.ResourceAssembly.Location);
            }
         };
            
         Application.Current.Shutdown(); // Environment.Exit(0); would also suffice 
    }
