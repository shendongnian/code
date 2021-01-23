    public class OptionsDialog : Window
    {
        public OptionsDialog(MyAppOptions options)
        {
            chkBooleanOption.IsChecked = options.SomeBooleanOption;
            txtStringOption.Text = options.SomeStringOption;
            btnOK.Click += new RoutedEventHandler(btnOK_Click);
            btnCancel.Click += new RoutedEventHandler(btnCancel_Click);
        }
    
        public MyAppOptions AppOptions
        {
            get;
            set;
        }
    
        void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.AppOptions.SomeBooleanOption = (Boolean) chkBooleanOption.IsChecked;
            this.AppOptions.SomeStringOption = txtStringOption.Text;
    
            // this is the key step - it will close the dialog and return 
            // true to ShowDialog
            this.DialogResult = true;
        }
    
        void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // this will close the dialog and return false to ShowDialog
            // Note that pressing the X button will also return false to ShowDialog
            this.DialogResult = false;
        }
    }
