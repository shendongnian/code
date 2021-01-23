    public class IdVersion
    {
        public int? Key { get; set; }
        public string Value { get; set; }
    }
    public class SomeModel 
    {
       public List<IdVersion> ItemIdVersion { get; set; } 
    }
