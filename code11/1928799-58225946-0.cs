    public static class Team
    {
        public static List<Person> GetPersons()
        {
            var person = new List<Person>();
            person.Add(new Person() { Name = "testPerson" });
            return person;
        }
    }
    public class Person
    {
        public string Name { get; set; }
    }
    public class Project
    {
        public string Name { get; set; }
        public string Scope { get; set; }
        public List<Person> Person
        {
            get
            {
                return Team.GetPersons();
            }
        }
    }
