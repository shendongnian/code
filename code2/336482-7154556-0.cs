    public class Person : IWorkPerson, IHomePerson
    {
        public string IWorkPerson.FirstName {get; set;}
        public string IWorkPerson.LastName { get; set; }
        public string IHomePerson.FirstName {get; set;}
        public string IHomePerson.LastName { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
    }
