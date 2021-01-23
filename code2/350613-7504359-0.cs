    public class Person
    {
        public string Name { get; set; }
        // what the hell is a yesno int? If it's 1 or 0 then just use a bool
        public int yesno { get; set; }
        public int Change { get; set; }
        public List<Cars> Personcars { get; set; }
        public Houses Personhouses { get; set; }
        public Merge(Person person)
        {
            Name = person.Name;
            Personcars.AddRange(person.Personcars);
        }
    }
