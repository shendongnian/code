    public class CustomerMap : ClassMapping<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.ID, map => map.Generator(Generators.HighLow,
                          gmap => gmap.Params(new {max_low = 100})));
            Property(x => x.Name,
                          map => { map.Length(150); map.NotNullable(true); });
            Bag(x => x.Addresses,
               collectionMapping =>
               {
                   collectionMapping.Table("CustomerAddresses");
                   collectionMapping.Cascade(Cascade.All);
                   collectionMapping.Key(k => k.Column("CustomerId"));
               });
        }
    }
