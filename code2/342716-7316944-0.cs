    public class Person
    {
        public virtual int Id { get; set; }
        internal protected virtual IList<long> VersionNumbers { get; set; }
        public virtual long VersionNumber {
           get { return VersionNumbers[VersionNumbers.Count - 1]; }
           set { VersionNumbers.Add(value); }
        }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string IdentificationNumber { get; set; }
    }
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("PersonDemographics");
            Id(p => p.Id, "PersonDemographicsId").GeneratedBy.Assigned();
            Map(p => p.FirstName);
            Map(p => p.LastName);
            Map(p => p.IdentificationNumber);
    
            HasMany(p => p.VersionRecord)
                .Table("PersonVersion")
                .KeyColumn("PersonDemographicsId")
                .Element("VersionNumber")
                .OrderBy("VersionNumber")
                .Cascade.All();
        }
    }
