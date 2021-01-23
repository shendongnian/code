    public class FooBar
    {
        public bool Problem()
        {
            //creates a default person object
            return Problem(new Person());
        }
        public void Problem(Person person)
        {
            //Some logic here
            return true;
        }
    }
    public class Person
    {
        public string Name { get; private set; }
        public DateTime DOB { get; private set; }
        public Person(string name, DateTime dob)
        {
            this.Name = name;
            this.DOB = dob;
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Person()
        {
            Name = "Michael";
            DOB = DateTime.Parse("1986-07-19");
        }
    }
