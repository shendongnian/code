    public class Warranty : AdvantageWebTable<WebObjs.Warranty>
    {
        [Advantage("id", IsKey = true)][Web("ID", IsKey = true)]
        public int programID;
        [Advantage("w_cost")][Web("Cost")]
        public decimal cost;
        [Advantage("w_price")][Web("Price")]
        public decimal price;
    
        public Warranty(int id)
        {
            this.programID = id;
            Initialize();
        }
    }
