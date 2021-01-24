    //Complex type class
    public class Address
    {
        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        public virtual string StateOrProvince { get; set; }
        public virtual string Country { get; set; }
    }
    
    //Entity
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual Address Address { get; set; }
        public virtual decimal Salary { get; set; }
    }
    
    //ComplexTypeConfiguration
    public class AddressMap : ComponentMap<Address>
    {
       public AddressMap()
       {
           Map(c => c.City).Column("City").Length(255).Not.Nullable();
           Map(c => c.Country).Column("Country").Length(255);
           Map(c => c.StateOrProvince).Nullable();
           Map(c => c.Street).Nullable();
       }
    }
    //Mapping
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("Employees");
            
            Id(c => c.Id);
            Map(c => c.FullName);
            Map(c => c.Salary);
            Component(c => c.Address);
        }
    }
    //Connection string
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(@"Server=.;Database=TestDB;Trusted_Connection=True;")
                .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
    
            Console.WriteLine("Database Connected");
            return sessionFactory.OpenSession();
        }
    }    
    //Test script    
    static void Main(string[] args)
    {
        using (ISession session = NHibernateHelper.OpenSession())
        {
            Employee employee = new Employee()
            {
                Id = 1,
                FullName = "Nidust Ashen",
                Salary = 12345678,
                Address = new Address()
                {
                    City = "test1",
                    Street = "test2",
                    Country = "test3",
                    StateOrProvince = "test4",
                }
            };
    
            session.Save(employee);
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
