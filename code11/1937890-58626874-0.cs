     public  class MyObjets : INotifyPropertyChanged
    {
       // public string Designation { get; set; }
      //  public string Description { get; set; }
     //   public float Prix { get; set; }
     //   public int nbr_objet { get; set; }
        int _nbr_objet;
        public int Nbr_objet
        {
            get
            {
                return _nbr_objet;
            }
            set
            {
                if (_nbr_objet != value)
                {
                    _nbr_objet = value;
                    OnPropertyChanged("Nbr_objet");
                }
            }
        }
        float _prix;
        public float Prix
        {
            get
            {
                return _prix;
            }
            set
            {
                if (_prix != value)
                {
                    _prix = value;
                    OnPropertyChanged("Prix");
                }
            }
        }
        string _designation;
        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                if (_designation != value)
                {
                    _designation = value;
                    OnPropertyChanged("Designation");
                }
            }
        }
        string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public MyObjets(string Designation, string Description, float Prix, int nbr_objet)
        {
            this._designation = Designation;
            this._description = Description;
            this._prix = Prix;
            this._nbr_objet = nbr_objet;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      }
     }
