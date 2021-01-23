    public class AccountSummary
    {
        public virtual uint Id { get; protected set; }
    
        public virtual Account Account { get; set; }
    
        public virtual string AccountNumber
        {
            get { return Account.AccountNumber; }
            set { Account.AccountNumber = value; }
        }
    
        public virtual DateTime TradeDate { get; set; }
    }
