    public class CompanyType{
        public int Id {get;set;}
        public string CompanyType {get;set;}
    }
    
    public class Company{
        public Company()
        {
            Employees = new HashSet<Employee>();
        }
        
        public int Id {get;set;}
        public string Company {get;set;}
        public int CompanyTypeID
        public virtual CompanyType CompanyType {get;set;}
        public virtual ICollection<Employee> Employees { get; set; }
    }
    public class Employee {
        public int Id {get;set;}
        public int CompanyID {get;set;}
        public virtual Company Company {get;set;}     
    }
    public class SomeContext : DbContext {
        public SomeContext() : base("SomeContext")
        {
        }
        public DbSet<CompanyType> CompanyTypeSet { get; set; }
        public DbSet<Employee> EmployeeSet { get; set; }
        public DbSet<Company> CompanySet { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
