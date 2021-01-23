    public class Person
    {
        public Person(string name = "Joe") // Will be "Joe" unless you say otherwise
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
    var me = new Person(); // Joe
    var you = new Person("You");
