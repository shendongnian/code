        public BaseForm()
        {
            InitializeComponent();
            _testValue = false;
        }
        private bool _testValue;
        [DefaultValue(true)]
        public bool TestProperty
        {
            get { return _testValue; }
            set { _testValue = value; }
        }
        protected override void OnVisibleChanged(EventArgs e)
        {            
            _testValue = true;
            base.OnVisibleChanged(e);
        }
    }
