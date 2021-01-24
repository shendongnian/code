    public class Person
    {
        public string id { get; set; }
        public string name { get; set; }
        public string age { get; set; }
    }
    
    public class RootObject
    {
        public List<Person> result { get; set; }
    }
