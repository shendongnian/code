    public class Company
    {
        private List<Person> _persons;
        private Person GetPersonByName(string name)
        {
            // My code to select Person is here, which is fine
        }
        public Person this[string name]
        {
            get { return GetPersonByName(name); }
        }
    }
