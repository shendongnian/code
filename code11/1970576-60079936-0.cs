    public class MapItem
    {
        [Key(Order = 1)]
        public long Item1ID {get; set;} //PK, FK
    
        [Key(Order = 2)]
        public int Item2ID {get; set;} //PK, FK
    
        public decimal Value {get; set;}
        public string Name {get; set;}
    
        public virtual Item1 {get; set;}
        public virtual Item2 {get; set;}
    }
