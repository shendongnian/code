        class Program
        {
            static void Main(string[] args)
            {
                Employee.GetSlaves();
      
            }
        }
        public partial class Employee
        {
            public static List<Employee> employees = new List<Employee>() {
                new Employee() {Id = 1, EmployeeName =  "John",  Position =  "CEO", ManagerId = null},
                new Employee() {Id = 2,EmployeeName =  "Marry", Position =  "Head of sales division", ManagerId = 1},
                new Employee() {Id = 3,EmployeeName =  "Mike", Position =  "Head of HR division", ManagerId = 1},
                new Employee() {Id = 4,EmployeeName =  "Jack", Position =  "Sales manager", ManagerId = 2},
                new Employee() {Id = 5,EmployeeName =  "Olivia", Position =  "Sales manager", ManagerId = 2},
                new Employee() {Id = 6,EmployeeName =  "Sophia", Position =  "Sales manager", ManagerId = 2},
                new Employee() {Id = 7,EmployeeName =  "Nadya", Position =  "HR manager", ManagerId = 3},
                new Employee() {Id = 8,EmployeeName =  "Tim", Position =  "HR manager", ManagerId = 3},
                new Employee() {Id = 9,EmployeeName =  "Jim", Position =  "Salesman", ManagerId = 4},
                new Employee() {Id = 10,EmployeeName =  "Sergey", Position =  "Salesman", ManagerId = 4},
                new Employee() {Id = 11,EmployeeName =  "Dmitry", Position =  "Salesman", ManagerId = 5},
                new Employee() {Id = 12,EmployeeName =  "Irina", Position =  "Salesman", ManagerId = 5},
                new Employee() {Id = 13,EmployeeName =  "William", Position =  "Assistant", ManagerId = 8}
            };
            public static void GetSlaves()
            {
                Employee ceo = employees.Where(x => x.ManagerId == null).First();
                GetSlavesRecursive(ceo);
            }
            public int Id { get; set; }
            public string EmployeeName { get; set; }
            public string Position { get; set; }
            public int? ManagerId { get; set; }
            public virtual ICollection<Employee> Slaves { get; set; }
            public virtual Employee Manager { get; set; }
            //public virtual ICollection<EmployeeDoc> EmployeeDocs { get; set; }
            static void GetSlavesRecursive(Employee manager)
            { 
                manager.Slaves  = employees.Where(x => x.ManagerId == manager.Id).ToList();
                foreach (Employee slave in manager.Slaves)
                {
                    GetSlavesRecursive(slave);
                }
            }
        }
