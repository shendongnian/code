    public Window1()
        {
            MyPerson = new Person();
            MyPerson.Name = "A";
            DataContext = MyPerson;
            InitializeComponent();
        }
        private Person myPerson;
        public Person MyPerson
        {
            get { return myPerson; }
            set { myPerson = value; OnPropertyChanged("MyPerson"); }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyPerson.Name = "B";
        }
