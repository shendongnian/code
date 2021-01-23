    public PeopleViewModel
    {
        public PeopleViewModel()
        {
            Items = new ObservableCollection<Person>();
        }
    
        public ObservableCollection<Person> Items { get; private set; }
    
        public int NumberOfPeople 
        { 
            get { return Items.Distinct().Count; }
        }
    }
