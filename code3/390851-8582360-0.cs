    class GiftCard
    {
        public long Id {get; private set;}
        public double Amount {get; private set;}
        public void Apply(Transaction tx)
        {
             if(tx.Amount > Amount)
             {
                handle insufficient funds
             }
             else
             {
                Amount -= tx.Amount;
                //other logic if necessary
             }
        }
    }
