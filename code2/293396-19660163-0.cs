    using System.Linq;
    namespace MyNamespace
    {
        public class MyClass
        {
            public DBContext db;
            public void MyMethod
            {
                foreach (var emp in db
                    .Employees
                    .Where(e => e.IsActive) // (or whatever)
                    .OrderBy(e => e.LastName))
                {
                    DoSomething(emp);
                }
            }
        }
    }
