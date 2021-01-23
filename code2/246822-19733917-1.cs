    public partial class CustomRTB : RichTextBox
    {
        public CustomRTB()
        {
            InitializeComponent();
        }
    
        protected override CreateParams CreateParams
        {
            get
            {
                //This makes the control's background transparent
                CreateParams CP = base.CreateParams;
                CP.ExStyle |= 0x20;
                return CP;
            }
        }
    }
