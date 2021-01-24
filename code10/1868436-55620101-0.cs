    public class Person
    {
        // address
        public string StreetAddress, Postcode, City;
        // employment
        public string CompanyName, Position;
        public int AnnualIncome;
        public Person()
        {
            Console.WriteLine("Person instanced");
        }
        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }
    public class PersonBuilder
    {
        protected static Person _person = new Person();
        public PersonAddressBuilder Lives => new PersonAddressBuilder(_person);
        public PersonJobBuilder Works => new PersonJobBuilder(_person);
        public Person Build()
        {
            return _person;
        }
    }
    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            _person = person;
        }
        public PersonJobBuilder At(string companyName)
        {
            _person.CompanyName = companyName;
            return this;
        }
        public PersonJobBuilder AsA(string position)
        {
            _person.Position = position;
            return this;
        }
        public PersonJobBuilder Earning(int annualIncome)
        {
            _person.AnnualIncome = annualIncome;
            return this;
        }
    }
    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            _person = person;
        }
        public PersonAddressBuilder At(string streetAddress)
        {
            _person.StreetAddress = streetAddress;
            return this;
        }
        public PersonAddressBuilder WithPostcode(string postcode)
        {
            _person.Postcode = postcode;
            return this;
        }
        public PersonAddressBuilder In(string city)
        {
            _person.City = city;
            return this;
        }
    }
    public class Demo
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb
              .Lives
                .At("123 London Road")
                .In("London")
                .WithPostcode("SW12BC")
              .Works
                .At("Fabrikam")
                .AsA("Engineer")
                .Earning(123000).Build();
            WriteLine(person);
            Console.ReadLine();
        }
    }
