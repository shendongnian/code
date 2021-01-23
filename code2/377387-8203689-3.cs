    public partial class UserControl1 : UserControl {
      public UserControl1() {
        InitializeComponent();
      }
      private void textBox1_HelpRequested(object sender, HelpEventArgs hlpevent) {
        //This prevents the UserControl from firing it's help request:
      }
    }
