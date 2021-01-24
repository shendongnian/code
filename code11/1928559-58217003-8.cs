    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new MainWindow_ModelView();
            }
        }
    
        public class MainWindow_ModelView : NotifyBase
        {
            private string _FilterString = String.Empty;
    
            public ObservableCollection<ItemClass> d_Items { get; set; }
            public ICollectionView md_LogEntriesStoreView { get; private set; }
    
            public string md_FilterString
            {
                get { return _FilterString; }
                set
                {
                    if (_FilterString != value)
                    {
                        _FilterString = value;
                        mf_MakeView();
                        OnPropertyChanged("md_FilterString");
                    }
                }
            }
    
            public MainWindow_ModelView()
            {
                d_Items = new ObservableCollection<ItemClass>() { new ItemClass() { d_Text1 = "Item1Text1", d_Text2 = "Item1Text2" }, 
                    new ItemClass() { d_Text1 = "Item2Text1", d_Text2 = "Item2Text2" }, 
                    new ItemClass() { d_Text1 = "Item3Text1", d_Text2 = "Item3Text2" } };
    
                md_LogEntriesStoreView = CollectionViewSource.GetDefaultView(d_Items);
            }
    
            private void mf_MakeView()
            {
                if (d_Items == null) return;
                md_LogEntriesStoreView = CollectionViewSource.GetDefaultView(d_Items);
                md_LogEntriesStoreView.Filter = mf_UserFilter;
                OnPropertyChanged("md_LogEntriesStoreView");
            }
            private bool mf_UserFilter(object item)
            {
                string s = _FilterString;
                if (String.IsNullOrWhiteSpace(s))
                    return true;
                else
                {
                    var srcT = item.GetType();
                    foreach (var f in srcT.GetFields())
                    {
                        string str = f.GetValue(item) as string;
                        if (String.IsNullOrWhiteSpace(str)) continue;
                        bool b = str.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0;
                        if (b) return true;
                    }
                    foreach (var f in srcT.GetProperties())
                    {
                        string str = f.GetValue(item, null) as string;
                        if (String.IsNullOrWhiteSpace(str)) continue;
                        bool b = str.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0;
                        if (b) return true;
                    }
    
                    return false;
                }
            }
        }
    
        public class ItemClass : NotifyBase
        {
            public string d_Text1 { get; set; }
            public string d_Text2 { get; set; }
        }
    
        public class NotifyBase : INotifyPropertyChanged
        {
            Guid id = Guid.NewGuid();
    
            [Browsable(false)]
            [System.Xml.Serialization.XmlAttribute("ID")]
            public Guid ID
            {
                get { return id; }
                set
                {
                    if (id != value)
                    {
                        id = value;
                        OnPropertyChanged("ID");
                    }
                }
            }
    
            [field: NonSerialized]
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
        }
