    public class Table2
    {
        public virtual int Key1 {get; set;}
        public virtual int Key2 {get; set;}
        [InverseProperty("Tables2")]
        [ForeignKey("Key1, Key2")]
        public virtual Table1 Table1 {get; set;}
       //more properties here...
    }
