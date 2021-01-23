        public MyView(IMyVM viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
