    class MyMoney
    {
        decimal Amount {get; set;}
        public MyMoney(decimal amount)
        {
            Amount = amount;
        }
        public override ToString()
        {
            return string.Format("${0}", Amount); 
        } 
    }
