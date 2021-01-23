    public PeopleGridViewModel
    {
        public ObservableCollection<Person> People;
        public Dictionary<string, string> PersonColumnHeaders;
        public PeopleGridViewModel()
        {
            // 1. write C# here to snag the property names from the typeof(Person)
            // 2. get the DisplayName attribute value for that property too.
            // 3. add the propertyName.ToString() and the DisplayName string to the dictionary as a key/value pair.
            // the result is you have a collection of column headers that start with the defaults from the propertys on the object... but they can be manipulated at run-time, and you don't havem them 100% hard typed like in adcool's example.
        }
    }
