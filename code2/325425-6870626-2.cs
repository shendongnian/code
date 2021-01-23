    public partial class MainWindow : Window
    {
        private CollectionViewSource cvs =  new CollectionViewSource();
    
        public CollectionViewSource CVS
        {
            get
            {
                return this.cvs;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<DateTime> list = new ObservableCollection<DateTime>();
            list.Add(new DateTime(2010, 2, 11));
            list.Add(new DateTime(2010, 7, 11));
            list.Add(new DateTime(2010, 7, 14));
            list.Add(new DateTime(2010, 2, 5));
            list.Add(new DateTime(2010, 3, 6));
            list.Add(new DateTime(2011, 1, 8));
            list.Add(new DateTime(2011, 7, 3));
            list.Add(new DateTime(2011, 1, 12));
            list.Add(new DateTime(2011, 2, 3));
    
            this.cvs.Source = list;
            this.cvs.GroupDescriptions.Add(new PropertyGroupDescription("Year"));
            this.cvs.GroupDescriptions.Add(new PropertyGroupDescription("Month"));
            this.DataContext = this;
        }
    }
