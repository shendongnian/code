    public class PersonBuilder {
        protected Person Person;
        
        private PersonBuilder() { Person = new Person(); }
        public static PersonBuilder Create() => new PersonBuilder();
        public PersonBuilder WithName(string name) {
            Person.Name = name;
            return this;
        }
        public PersonBuilder HavingJob(Action<IJobBuilder> configure) {
            var builder = new JobBuilder();
            configure(builder);
            Person.Jobs.Add(builder.Build());
            return this;
        }
        public Person Build() => Person;
    }
