    public class AccountRegistrationFieldMap : ClassMap<AccountRegistrationField>
    {
        public AccountRegistrationFieldMap()
        {
            Table("AccountRegistrationField");
            
            Id(r => r.ID).Column("RegistrationID");
            Map(r => r.AccountID);
            Map(r => r.DefaultValue);
            Map(r => r.IsRequired);
            Map(r => r.Label);
            Map(r => r.Priority);
            References<RegistrationField>(
                     Reveal.Member<AccountRegistrationField>("RegistrationField"))
                .Column("FieldID");
            
        }
    }
