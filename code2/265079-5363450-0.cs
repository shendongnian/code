    internal enum Gender
    {
        Male,
        Female
    }
    
    internal class Person
    {
        public Gender Gender { get; set; }
    
        public string Name { get; set; }
    }
    
    // . . .
    
    // Populate the list of people
    List<Person> allPeople = new List<Person>();
    allPeople.Add(new Person() { Gender = Gender.Male, Name = "Xxx Yyy" });
    allPeople.Add(new Person() { Gender = Gender.Female, Name = "Www Zzz" });
    
    // . . .
