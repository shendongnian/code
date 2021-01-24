    class Class
    {
        private Person person = new Person();
        public void NamePerson()
        {
            person.Name = "Peter";
        }
    
        public IPerson CPerson
        {
            get
            {
                return person;
            }
        }    
    }
