    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {       
            Id(x => x.PersonId);
            Map(x => x.PersonName).Not.Nullable();
            Map(x => x.Birthdate).Not.Nullable();                   
            Component(x => x.Birthplace).ColumnPrefix("birthplace_");
    
            HasMany(x => x.Contacts).KeyColumn("yyyy").Inverse(); // must add .KeyColumn
    
        }
    }//PersonMap
