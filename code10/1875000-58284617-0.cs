    [Owned]
    public class Audit {
        public string By {get; set;}
        public DateTime At {get;set;}
    }
    public class Organisation {
        public Guid Id {get;set;}
        public Audit Created {get;set;}
        // other properties omitted 
    }
