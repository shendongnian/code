    [assembly: Dependency(typeof(UWPFileLauncher))]
    
    namespace App14.UWP
    {
        public class UWPFileLauncher : IFileLauncher
        {
            public async Task<bool> LaunchFileAsync(string uri)
            {
                var file = await Windows.Storage.StorageFile.GetFileFromPathAsync(uri);
                bool success = false;
                if (file != null)
                {
                    // Set the option to show the picker
                    var options = new Windows.System.LauncherOptions();
                    options.DisplayApplicationPicker = true;
    
                    // Launch the retrieved file
                     success = await Windows.System.Launcher.LaunchFileAsync(file, options);
                    if (success)
                    {
                        // File launched
                    }
                    else
                    {
                        // File launch failed
                    }
                }
                else
                {
                    // Could not  
                }
                return success;
            }
        }
    }
