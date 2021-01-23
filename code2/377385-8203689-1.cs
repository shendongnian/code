    public partial class UserControl1 : UserControl {
      public UserControl1() {
        InitializeComponent();
      }
      private void UserControl1_HelpRequested(object sender, HelpEventArgs hlpevent) {
        this.BackColor = Color.Yellow;
      }
    }
