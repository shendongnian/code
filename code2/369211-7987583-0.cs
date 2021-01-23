    public class Table2
    {
        [ForeignKey("Table1"), Column(Order = 1)]
        public virtual int Key1 {get; set;}
        [ForeignKey("Table1"), Column(Order = 2)]
        public virtual int Key2 {get; set;}
        [InverseProperty("Tables2")]
        public virtual Table1 Table1 {get; set;}
       //more properties here...
    }
