        public CustomView()
        {
            InitializeComponent();
            this.SizeChanged += CustomView_SizeChanged;
        }
        private void CustomScrollView_SizeChanged(object sender, EventArgs e)
        {
            ChangeScale();
        }
