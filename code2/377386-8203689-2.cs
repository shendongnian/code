    public partial class UserControl1 : UserControl {
      public UserControl1() {
        InitializeComponent();
      }
    }
    public partial class Form1 : Form {
      public Form1() {
        InitializeComponent();
        userControl11.Tag = "http://www.stackoverflow.com";
        userControl11.HelpRequested += userControl11_HelpRequested;
      }
      private void userControl11_HelpRequested(object sender, HelpEventArgs hlpevent) {
        string tag = ((Control)sender).Tag.ToString();
        if (!string.IsNullOrEmpty(tag)) {
          try {
            ProcessStartInfo sInfo = new ProcessStartInfo(tag);
            Process.Start(sInfo);
          }
          catch (Exception) { }
        }
        hlpevent.Handled = true;
      }
    }
