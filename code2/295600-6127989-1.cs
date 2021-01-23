    public class Person
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
    
    Person person = new Person();
    person.Name = "Andre";
