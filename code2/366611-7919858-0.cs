        private TestProperties _properties;
        public TestProperties Properties
        {
            get { return _properties; }
            set
            {
                _properties = value;
                this.bindingSource1.DataSource = _properties;
            }
        }
        public UserControl1()
        {
            InitializeComponent();
        }
