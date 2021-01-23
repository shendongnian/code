    class Person
    {
        public Person(string name = "John")
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
            set 
            {
                if (!String.Equals(value, name))
                {
                    name = value;
                    OnNameChanged();
                }
            }
        }
        public event EventHandler NameChanged;
        protected virtual void OnNameChanged()
        {
            EventHandler nameChanged = NameChanged;
            if (nameChanged != null)
            {
                nameChanged(this, new EventArgs());
            }
        }
        private string name;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.NameChanged += person_NameChanged;
            person.Name = "Paul";
        }
        static void person_NameChanged(object sender, EventArgs e)
        {
            Person person = (Person)sender;
            Console.WriteLine("The name changed!");
            Console.WriteLine("It is now: " + person.Name);
        }
    }
