    class SchoolBookViewModel : INotifyPropertyChanged
    {
        private SchoolList _selectedSchoolClass;
        public SchoolList SelectedSchoolClass
        {
            get { return _selectedSchoolClass; }
            set
            {
                _selectedSchoolClass = value;
                ClassBookListEntries = SchoolQuoteList.GetSchoolClassQuoteListBySchoolClassID(_selectedSchoolClass.Id, 2011, "MyConnectionString");
                NotifyPropertyChanged("SelectedSchoolClass");
            }
        }
        private SchoolQuoteList _classBookListEntries;
        public SchoolQuoteList ClassBookListEntries
        {
            get { return _classBookListEntries; }
            set
            {
                _classBookListEntries = value;
                NotifyPropertyChanged("ClassBookListEntries");
            }
        }
        private SchoolList _schoolEntries;
        public SchoolList SchoolEntries
        {
            get
            {
                if (_schoolEntries == null)
                    _schoolEntries = SchoolList.GetSchoolList("MyConnectionString");
                return _schoolEntries;
            }
        }
        ...
    }
