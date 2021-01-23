    public class PeopleInfo {
        public virtual int Id { get; set; }
        public virtual IList<Person> People { get; set; }
    }
    public class Person {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual PeopleInfo PeopleInfo { get; set; }
    }
    public class PeopleInfoMap : ClassMap<PeopleInfo> {
        public PeopleInfoMap() {
            Id(x => x.Id);
            HasMany(x => x.People)
                .Cascade.None()
                .Inverse();
        }
    }
    public class PersonMap : ClassMap<Person> {
        public PersonMap() {
            Id(x => x.Id);
            Map(x => x.Name);
            References(x => x.PeopleInfo);
        }
    }
