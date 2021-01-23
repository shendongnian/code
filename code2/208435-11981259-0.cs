    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("Person");
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany<PhoneNumber>(x => x.PhoneNumberList)
                .KeyColumn("PersonId")
                .Cascade.All()
                .Inverse().LazyLoad();
        }
    }
