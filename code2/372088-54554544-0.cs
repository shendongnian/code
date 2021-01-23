     public partial class HintComboBox : ComboBox
    {
        string hint;
        Font greyFont;
        [Localizable(true)]
        public string Hint
        {
            get { return hint; }
            set { hint = value; Invalidate(); }
        }
        public HintComboBox()
        {
            InitializeComponent();
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (string.IsNullOrEmpty(Text))
            {
                this.ForeColor = SystemColors.GrayText;
                Text = Hint;
            }
            else
            {
                this.ForeColor = Color.Black;
            }
        }
        private void HintComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( string.IsNullOrEmpty(Text) )
            {
                this.ForeColor = SystemColors.GrayText;
                Text = Hint;
            }
            else
            {
                this.ForeColor = Color.Black;
            }
        }
