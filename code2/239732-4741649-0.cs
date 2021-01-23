    interface IPerson
    {
        ICollection<string> NickNames { get; set; }
    }
    class ObservablePerson : IPerson
    {
        public new ObservableCollection<string> NickNames { get; set; }
        ICollection<string> IPerson.NickNames
        {
            get { return NickNames; }
            set { NickNames = (ObservableCollection<string>)value; }
        }
    }
    class ListPerson : IPerson
    {
        public new List<string> NickNames { get; set; }
        ICollection<string> IPerson.NickNames
        {
            get { return NickNames; }
            set { NickNames = (List<string>)value; }
        }
    }
