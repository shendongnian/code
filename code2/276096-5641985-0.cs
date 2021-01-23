    public class Person
    {
        public Person()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
    
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Group
    {
        public Group()
        {
            Id = ObjectId.GenerateNewId().ToString();
            persons = new List<Person>();
        }
    
        [BsonId]
        public string Id { get; set; }
        public string Description { get; set; }
                
        public List<Person> persons { get; set; }
    
        public void Add(Person p)
        {
            persons.Add(p);
        }
    }
