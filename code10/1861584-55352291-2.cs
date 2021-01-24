        public static MainPage Form { get; set; } // This Line
        public MainPage()
        {
            InitializeComponent();
            Form = this; // And This Line
        }
