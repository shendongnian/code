public static EventWaitHandle ApplicationMutex { get; set; }
        /// <summary>Handles the application startup sequence</summary>
        /// <param name="sender">The App.xaml file</param>
        /// <param name="e"><see cref="StartupEventArgs"></see></param>
        private async void Application_Startup(object sender, StartupEventArgs e) {
            var appName = Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().MainModule?.FileName);
            // We create a mutex here that lasts for the lifetime of our program to stop users from
            // opening two windows at once
            ApplicationMutex = new EventWaitHandle(false, EventResetMode.ManualReset, appName, out var created);
            if (!created) {
                if (ApplicationMutex != null)
                    Log.Error("Failed to create mutex");
                Current.Shutdown();
            }
with the following code in the main window:
 ~MainWindow() {
            App.ApplicationMutex.Dispose();
        }
this does exactly what you want it to do 
