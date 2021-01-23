    	    /// <summary>
	    /// Interaktionslogik für MainWindow.xaml
	    /// </summary>
	    /// 
	    public partial class MainWindow : Window
	    {
	        static string[,] culture = new string[,] { { "ar-SA", "Arabic", "Saudi Arabia" }, { "de-DE", "German", "Germany" },
	                                                   { "en-GB", "English", "United Kingdom"}, // { "en-US", "English", "United States of America"}, 
	                                                   { "no", "Norwegian (Bokmål)", "Norway"}, { "sv-SE", "Swedish", "Sweden"},
	                                                   { "tr", "Turkish", null } };
	        static string[] label = new string[] { "Caption", "Message" };
	        static short selectedCulture = 1;   // de-DE
	        ResourceManager rm = null;
	        public MainWindow()
	        {
	            InitializeComponent();
	            textBox1.AppendText(culture[selectedCulture, 1]);
	            Keyboard.Focus(btnMessage);
	        }
	        private void btnMessage_Click(object sender, RoutedEventArgs rea)
	        {
	            const string METHOD = "MainWindow:btnMessage_Click: ";
	            try
	            {
	                DetermineResourceManager();
	                if (culture[selectedCulture, 0].Substring(0, 2) != "ar")
	                {
	                    MessageBox.Show(rm.GetString(label[1]), rm.GetString(label[0]),
	                        MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.None);
	                }
	                else
	                {
	                    MessageBox.Show(rm.GetString(label[1]), rm.GetString(label[0]),
	                        MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.None,
	                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
	                }
	            }
	            catch (MissingManifestResourceException mmre)
	            {
	                MessageBox.Show(METHOD + "Exception: " + mmre, "Error");
	            }
	            catch (Exception e)
	            {
	                MessageBox.Show(METHOD + "Unexpected exception: " + e, "Error");
	            }
	            SwitchLanguage();
	            textBox1.Text = culture[selectedCulture, 1];
	        }
	        private void DetermineResourceManager()
	        {
	            const string METHOD = "MainWindow:DetermineResourceManager(): ";
	            string resource = "WpfApplication1.Resource." + culture[selectedCulture, 0] + ".resources";
	            try
	            {
	                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture[selectedCulture, 0], false);
	                rm = new ResourceManager("WpfApplication1.Resource", Assembly.GetExecutingAssembly());
	            }
	            catch (Exception e)
	            {
	                MessageBox.Show(METHOD + ", unexpected exception: " + e);
	                throw e;
	            }
	        }
	        private void SwitchLanguage()
	        {
	            if (++selectedCulture >= culture.Length/3)
	                selectedCulture = 0;
	        }
	    }
	}
