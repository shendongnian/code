    namespace MyProgram
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            private void Application_Startup(object sender, StartupEventArgs e)
            {
                if (Application.Current.Properties["ArbitraryArgName"] != null)
                {
                    string fname = Application.Current.Properties["ArbitraryArgName"].ToString();
    
                    readVcard(fname);
    
                }
            }
        }
    }
