        # region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            this.DataContext = new AccountListViewModel();
        }
        # endregion
