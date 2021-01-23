    class Person
    {  
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Address = "Unknown";
            Email = "Unknown";
        }
    
        public string Name {get; private set;}
        public int Age {get; private set;}
    
        public string Email {get; set;}
        public string Address {get; set;}
    }
    Person p = new Person("John Doe", 30);
    p.Email = "john.doe@example.org";
