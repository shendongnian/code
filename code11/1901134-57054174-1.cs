      public partial class TabbedPage2 : TabbedPage
    {
        public TabbedPage2 ()
        {
            InitializeComponent();
            this.BindingContext = new ListePageViewModel();
        }     
    }
    public class OlonaModel
    {
        public int Numero { get; set; }
        public string Text { get; set; }
    }
    public class ListePageViewModel : ViewModelBase
    {
        public ObservableCollection<OlonaModel> listeOlonaVM { get; set; }
        private OlonaModel _select;
        public OlonaModel select
        {
            get { return _select; }
            set
            {
                _select = value;
                RaisePropertyChanged("select");
            }
        }
        public ListePageViewModel()
        {
            listeOlonaVM = new ObservableCollection<OlonaModel>()
            {
                new OlonaModel(){Numero=1,Text="first item"},
                new OlonaModel(){Numero=2,Text="second item"},
                new OlonaModel(){Numero=3,Text="third item"},
                new OlonaModel(){Numero=4,Text="fouth item"}
            };
            select = listeOlonaVM[0];
        }
    }
