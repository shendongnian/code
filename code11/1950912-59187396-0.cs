    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            model m = new model();
            m.Name = "name_1";
            BindingContext = m;
        }
    }
    class model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public model()
        {
        }
        public string Name
        {
            get { return Preferences.Get("Consts.PREF_NAME", ""); }
            set
            {
                Preferences.Set("Consts.PREF_NAME", value);
                if (PropertyChanged != null)
                   {
                        PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                    }           
            }
        }
    }
