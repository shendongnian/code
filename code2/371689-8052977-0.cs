    public partial class MainWindow : Window, INotifyPropertyChanged
    {
          private ObservableCollection<MyDataClass> m_myList;
          public ObservableCollection<MyDataClass> _myList
          {
             get
             {
                 return m_myList;
             }
             set
             {
                 m_myList = value;
                 RaisePropertyChanged("_myList");
             }
          }
    
          public MainWindow()
          {
               InitializeComponent();
               _myList = new ObservableCollection<MyDataClass>();
               comboBox1.DataContext = _myList;
          }
    
          private void Button_Click(object sender, EventArgs e)
          {
               _myList = AnotherClass.SomeMethod();
          }
    
          //Implement INotifyPropertyChanged here
          //...
    }
