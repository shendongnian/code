    public class CustomerMap : FluentNHibernate.Mapping.ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id);
    
            Map(x => x.Firstname).Length(256);
            Map(x => x.Lastname).Length(256);
            Map(x => x.Birthdate);
    
            HasManyToMany(x => x.Addresses)
                .Table("CustomerAddress")
                .Inverse()
                .Cascade.All();
        }
    }
