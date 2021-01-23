        //public int Id 
        //{ get; set; }
        //public string Name { get; set; }
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value;
            RaisePropertyChanged("Id");
            }
        }
        private string _EmpNo
        {
            get
            {
                return Id.ToString() + Name.ToString();
            }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value;
            RaisePropertyChanged("Name");
            }
        }
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
