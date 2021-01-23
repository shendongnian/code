    public class MyControl
    {
        public event CancelEventHandler Validating;
        public System.Windows.Forms.TextBox innerTextBox;
        public MyControl()
        {
            //post-instantiation stuff here
            innerTextBox.Validating += myName_Validating;
        }
        void myName_Validating(oject sender, CancelEventArgs e)
        {
            if (Validating != null) 
            {
                Validating(sender, e);
            }
        }
    }
