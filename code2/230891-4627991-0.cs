    public class PersonViewModel : ViewModelBase
    {
        private readonly ModelDataStore<Person> data;
        public PersonViewModel()
        {
            data = new ModelDataStore<Person>(new Person());
        }
        public PersonViewModel(Person person)
        {
            data = new ModelDataStore<Person>(person);
        }
        #region Properties
        #region Name
        public string Name
        {
            get { return data.Model.Name; }
            set { data.SetPropertyAndRaisePropertyChanged("Name", value, this); }
        }
        #endregion
        #region Age
        public int Age
        {
            get { return data.Model.Age; }
            set { data.SetPropertyAndRaisePropertyChanged("Age", value, this); }
        }
        #endregion
        #endregion
    }
