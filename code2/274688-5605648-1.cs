    public partial class CustomTextbox : TextBox
    {
        public CustomTextbox()
        {
            InitializeComponent();            
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            
        }
    } 
