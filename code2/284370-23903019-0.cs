    public partial class MyTextBox : TextBox
    {
        [DefaultValue(false)]
        [Browsable(true)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }
        public MyTextBox()
        {
            InitializeComponent();
            this.AutoSize = false;
        }
