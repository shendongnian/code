    public partial class App : Application
    {
        /// <summary>
        /// Creates a new <see cref="App"/> instance.
        /// </summary>
        public App()
        {
            Application.Current.CheckAndDownloadUpdateAsync();
            // rest of code
