    using FluentNHibernate.Mapping;
    namespace Models.Mapping
    {
        public class CustomerMap : ClassMap<Customer>
        {
            public CustomerMap()
            {
                Table("Customer");
                Id(customer => customer.Id);
                Map(customer => customer.Name).Column("client_name").Not.Nullable();
                Map(ssc => customer.ssc).Column("social_security_numer");
               
                References(customer => customer.User);
            }
        }
    }
