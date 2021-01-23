    public class Person
    {
        public Person()
            : this("Joe") // Calls the other constructor that takes a name...
        {
        }
        public Person(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
    var me = new Person(); // Joe
    var you = new Person("You");
