     public class ViewModelBase: INotifyPropertyChanged
    {
        public ViewModelBase()
        {
            ObjetVM = new MyObjets("ccc","xxx",1.2f,123);
        }
    public MyObjets ObjetVM { get; set; }
        public int nbr_objet
        {
            get { return ObjetVM.nbr_objet; }
            set
            {
                ObjetVM.nbr_objet = value;
                OnPropertyChanged(nameof(ObjetVM.nbr_objet));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string propertyname)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }
