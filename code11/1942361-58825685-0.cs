        //Domain Business layer logic
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        void Update(Person person);
    }
