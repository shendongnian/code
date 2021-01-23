        // CONSTRUCTOR
        public SomeView()
        {
            InitializeComponent();
            DataContextChanged += DataContextChangedHandler;
        }
        void DataContextChangedHandler(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = e.NewValue as IInterfaceToBeImplementedByViewModel;
            if (viewModel != null)
            {
                viewModel.SomeEvent += (sender, args) => { someMethod(); }
            }
        }
