    class Person
    {
        public Person(string name,
                      string age,
                      string city)
        {
            this.Name = name;
            this.Age = age;
            this.City = city;
        }
        public string Name { get; private set; }
        public string Age { get; private set; }
        public string City { get; private set; }
        public void SerializeToFile()
        {
            //Do the serialization (saving the person to a file) here.
        }
    }
