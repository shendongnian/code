    namespace NHibernateTest.Database {
        public class Employee {
            public Employee(Employer employer) { EmployerId = employer.Id; }
            protected Employee() {} // nHibernate needs access to a parameterless constructor.
            public virtual long Id { get; set; }
            protected virtual long EmployerId { get; set; }
            public virtual string FirstName { get; set; }
            public virtual string LastName { get; set; }
            public virtual string Email { get; set; }
        }
    
        public class Employer {
            public virtual long Id { get; set; }
            public virtual string Name { get; set; }
            public virtual IList<Employee> Employees { get; set; }
        }
    }
