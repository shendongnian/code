      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
        }
      }
    
      public class AllNamesProvider 
      {
        public AllNamesProvider()
        {
          AllNames = new ObservableCollection<Name>
          {
            new Name { FirstName = "aaaa", LastName = "AAAA" },
            new Name { FirstName = "bbbb", LastName = "BBBB" },
            new Name { FirstName = "cccc", LastName = "CCCC" },
            new Name { FirstName = "dddd", LastName = "DDDD" },
            new Name { FirstName = "eeee", LastName = "EEEE" },
            new Name { FirstName = "ffff", LastName = "FFFF" },
          };
        }
    
    
        public ObservableCollection<Name> AllNames
        {
          get;
        }
      }
    
      public class Name : INotifyPropertyChanged
      {
        private string m_firstName;
        public string FirstName
        {
          get { return m_firstName; }
          set
          {
            m_firstName = value;
            OnPropertyChanged("FirstName");
          }
        }
    
        private string m_lastName;
        public string LastName
        {
          get { return m_lastName; }
          set
          {
            m_lastName = value;
            OnPropertyChanged("LastName");
          }
        }
    
        private void OnPropertyChanged(string v)
        {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
      }
    
      public class Person : INotifyPropertyChanged
      {
        private int m_id;
        public int Id
        {
          get { return m_id; }
          set
          {
            m_id = value;
            OnPropertyChanged("Id");
          }
        }
    
        private string m_name;
        public string Name
        {
          get { return m_name; }
          set
          {
            m_name = value;
            OnPropertyChanged("Name");
          }
        }
    
    
        private void OnPropertyChanged(string v)
        {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
      }
    
    
      public class ViewModel
      {
        public ViewModel()
        {
          Persons = new ListCollectionView(new List<Person>
          {
            new Person { Id = 1, Name = "AAAA"},
            new Person { Id = 2, Name = "BBBB"},
            new Person { Id = 3, Name = "CCCC"},
          });
        }
    
    
        public ListCollectionView Persons { get; set; }
    
        void RaisePropertyChanged()
        {
    
        }
      }
    
