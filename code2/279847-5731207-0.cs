    public class MyObject
    {
        [Key]
        public int Id { get; set; }
        protected decimal MyMoney { get; set; }
        public Money MyMoneyStruct 
        { 
            get { return (Money)this.MyMoney; } 
            set { this.MyMoney = (decimal)value; }
        }
    }
