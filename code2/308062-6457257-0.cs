    public class SubAccount
    {
        public virtual int Id { get; private set; }
        public virtual Account Account { get; private set; }
        protected virtual decimal Value { get; set; }
        public virtual Money Balance { get { return new Money(Value, Account.Currency); } }
    }
    public class SubAccountMap : ClassMap<SubAccount>
    {
        public SubAccountMap()
        {
            Table("SubAccount");
    
            Id(x => x.Id)
                .Column("AccountId");
            References(x => x.Account)
                .Column("AccountId");
    
            Map(Reveal.Property<decimal>("Value"));
        }
    }
