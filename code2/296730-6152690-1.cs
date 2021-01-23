    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public static implicit operator Person(string name)
        {
            return new Person(name);
        }
    }
    var list = new List<Person>();
    list.Add("Terry");
