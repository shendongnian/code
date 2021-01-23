    public partial class CustomDialog : Window
    {
        ....
        TextBox tb = new TextBox();
        ....
        public void ShowBox()
        {
           ....
           this.Loaded += CustomDialog_Loaded;
           ....
        }
    }
    void CustomDialog_Loaded(object sender, RoutedEventArgs e)
    {
        tb.Focus();
    }
