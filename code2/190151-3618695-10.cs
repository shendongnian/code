        static void Main ()
        {
            Person[] p = 
            {
                new Person{Age = 20, Firstname = "Michael", Lastname = "Jackson"},
                new Person{Age = 21, Firstname = "Bill", Lastname = "Gates"},
                new Person{Age = 22, Firstname = "Steve", Lastname = "Jobs"}
            };
            SerializeObject<Persons>(new Persons(p));
            Person[] p2 = DeserializeObject<Persons>("filename.xml").ToArray();
        }
