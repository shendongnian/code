        public BaseForm()
        {
            InitializeComponent();
            checkBox1.Visible = _controlVisible = true;
        }
        private bool _controlVisible;
        [DefaultValue(true)]
        public bool ControlVisible
        {
            get { return _controlVisible; }
            set { _controlVisible = checkBox1.Visible = value; }
        }
