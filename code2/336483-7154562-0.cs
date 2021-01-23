    class Person : IWorkPerson, IHomePerson 
    {
        public string IWorkPerson.FirstName {get; set; }
        public string IHomePerson.FirstName {get; set; }
        // etc...
     }
