    class Person
    {
        internal Person(string name, IReadOnlyList<Person> friends)
        {
            Name = name; Friends = friends
        }
    
        public string Name { get; }
        public IReadOnlyList<Person> Friends {get; internal set;}
    }
    
    class SerializedPerson { ... }
    
    IEnumerable<Person> LoadPeople(string path)
    {
        var serializedPeople = LoadFromFile(path);
        
        // Note the use of null!
    	var people = serializedPeople.Select(p => new Person(p.Name, null!));
    	
    	foreach(var person in people)
    	{
    		person.Friends = GetFriends(person, people, serializedPeople);
    	}
        return people;
    }
