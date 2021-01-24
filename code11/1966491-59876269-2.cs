     public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
              //  this.DataContext = this; Uncomment this if code behind is your datacontext
                InitializeComponent();
                DataTable t1 = new DataTable();
                t1.Columns.Add("Name");
                t1.Columns.Add("Age");
                t1.Rows.Add("A", "1");
                t1.Rows.Add("B", "2");
                DataTable t2 = new DataTable();
                t2.Columns.Add("Name");
                t2.Columns.Add("Age");
                t2.Rows.Add("A", "1");
                DtList = new List<DataTable> { t1, t2 };
            }
            private List<DataTable> dtList;
            public List<DataTable> DtList
            {
                get { return dtList; }
                set
                {
                    dtList = value;
                    OnPropertyChanged("DtList");
                }
            }
            private string selectedName;
            public string SelectedName
            {
               get { return selectedName; }
               set
               {
                  selectedName = value;
                  OnPropertyChanged("SelectedName");
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
