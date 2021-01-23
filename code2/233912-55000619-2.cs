    public partial class wndMain : Window
    {
        public string LangSwitch { get; private set; } = null;
        // ... blah, blah, blah
        private void tbEn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LangSwitch = "en";
            Close();
        }
        private void tbHu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            LangSwitch = "hu-hu";
            Close();
        }
        // ... blah, blah, blah
    }
