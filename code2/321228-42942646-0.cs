    public partial class ActionDialog : Window
    {
        
        public ActionDialog(string msg)
        {
            InitializeComponent();
            MsgTbx.Text = msg;
        }
        //Record the user's click result
        public bool ClickResult = false;
        //In Other place need to use this Dialog just Call this Method
        public static bool EnsureExecute(string msg)
        {
            ActionDialog dialogAc = new ActionDialog(msg);
            //this line will run through only when dialogAc is closed
            dialogAc.ShowDialog(); 
            //the magic is the property ClickResult of dialogAc
            //can be accessed even when it's closed
            return dialogAc.ClickResult;
        }
       
        //add this method to your custom OK Button's click event        
        private void Execute_OnClick(object sender, RoutedEventArgs e)
        {
            ClickResult = true;
            this.Close();
        }
        //add this method to your custom Cancel Button click event       
        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            ClickResult = false;
            this.Close();
        }
    }
