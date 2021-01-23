     public List<Person> source = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
          
            for (int i = 0; i < 20; i++)
            {
                source.Add(new Person() { PersonID = i.ToString(), PersonName = "Sau" + i.ToString() });
            }
            cmb.ItemsSource = source;
            this.DataContext = this;
        }
