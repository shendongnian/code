        Player ViewModel { get; set; }
        public PlayerDetailPage(Player player)
        {
            InitializeComponent();
            this.BindingContext = ViewModel = player;
        }
