     public partial class MainWindow : Window
        {
            public MainWindow()
            {
                this.DataContext = this;
                InitializeComponent();
                TestItems = new ObservableCollection<string>()
                {
                    "Apple",
                    "Banana",
                    "Carrot",
                    "Dog",
                    "Elderberry",
                    "Fruit",
                    "Grapes",
                    "Honey",
                    "Iron"
                };
            }
    
            private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
            {   
                Person[] peopleArray = new Person[3]
                {
                    new Person("John"),
                    new Person("Jim"),
                    new Person("Sue"),
                };
    
                People peopleList = new People(peopleArray);
                foreach (Person p in peopleList)
                    Console.WriteLine(p.Name);
                Console.ReadLine();
            }
            
        private ObservableCollection<string> testItems ;
        public ObservableCollection<string> TestItems 
        {
            get { return testItems; }
            set
            {
                testItems= value;
                OnPropertyChanged("TestItems");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler == null) return;
            handler(this, new PropertyChangedEventArgs(name));
        }
     }
