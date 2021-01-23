    public class EVProjectLedger
    {
        public virtual long Id { get; protected set; }
        public virtual string ProjId { get; set; }
        public virtual string Ledger { get; set; }
        public virtual AccountRule AccountRule { get; set; }
        public virtual int AccountLength { get; set; }
        public virtual string AccountSubstrMethod { get; set; }
    
        private Iesi.Collections.Generic.ISet<Contract> myContracts = new HashedSet<Contract>();
    
        public virtual Iesi.Collections.Generic.ISet<Contract> Contracts
        {
            get { return myContracts; }
            set { myContracts = value; }
        }
    
        public override bool Equals(object obj)
        {
            EVProjectLedger evProjectLedger = (EVProjectLedger)obj;
            return ProjId == evProjectLedger.ProjId && Ledger == evProjectLedger.Ledger;
        }
        public override int GetHashCode()
        {
            return new { ProjId, Ledger }.GetHashCode();
        }
    }
