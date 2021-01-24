    public class Person
    {
        private string _name;
        public Person() // Default constructor is required if there are any other constructors!
        {
            Name = "";
        }
        public Person(Person other) // Copy constructor.
        {
            this.Name = other.Name;
        }
        public Person Copy()
        {
            return new Person(this); // Use copy constructor to return a copy of this.
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public void Change()
        {
            Name = "F";
        }
    }
