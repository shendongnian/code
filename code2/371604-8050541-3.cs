    public class Person
    {
        public House MyHouse { get; set; }
    }
    public class House
    {
        public List<Person> Members { get; private set; }
        public House()
        {
            this.Members = new List<Person>();
        }
    }
