    public class MyObject
    {
        [Key]
        public int Id { get; set; }
        public Money MyMoney { get { return (Money)MyMoneyInternal; } set { MyMoneyInternal = (decimal)value; } }
        private decimal MyMoneyInternal { get; set; }
    }
