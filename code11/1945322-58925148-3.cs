    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Database DB = new Database();
                var results = (from e in DB.Employees
                               join t in DB.Tasks on e.ID equals t.EmployeeID
                               join p in DB.Projects on t.ProjectID equals p.ID
                               select new { employee = e, task = t, project = p }
                              ).ToList();
            }
        }
        public class Database
        {
            public List<Employees> Employees { get; set; }
            public List<Project> Projects { get; set; }
            public List<Task> Tasks { get; set; }
        }
        public class Employees
        {
            public int ID { get; set; }
        }
        public class Project
        {
            public int ID { get; set; }
        }
        public class Task
        {
            public int EmployeeID { get; set; }
            public int ProjectID { get; set; }
        }
    }
