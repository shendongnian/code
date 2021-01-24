    [assembly: Dependency(typeof(AndroidIsInstallApplication))]// do not miss the line
    namespace App18.Droid
    {
       class AndroidIsInstallApplication : IsInstallApplication
         {
            public bool IsInstall(string applicationName)
             {
                ... //here you could use Package manager to get the installation status of the application like in native android
                return true;
             }
         }
    }
