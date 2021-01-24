     public List<string> list { get; set; }
        public Page2()
        {
            InitializeComponent();
            list = new List<string> { "1", "2", "3", "4" };
            this.BindingContext = this;
        }
