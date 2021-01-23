    public class CatalogoModel 
    {
        private String _Id;
        private String _Descripcion;
        private Boolean _IsChecked;
        public String Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public Boolean IsChecked
        {
            get { return _IsChecked; }
            set
            {
               _IsChecked = value;
                NotifyPropertyChanged("IsChecked");
                OnItemChecked.Invoke();
            }
        }
        public static Action OnItemChecked;
    } 
    public class ReglaViewModel : ViewModelBase
    {
        private ObservableCollection<CatalogoModel> _origenes;
        CatalogoModel.OnItemChecked = () =>
                {
                    var x = Origenes.Count;  //Entra cada vez que cambia algo en _origenes
                };
    }
