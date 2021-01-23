        static void Main(string[] args)
        {
            Employee emp = new Employee();
            Manager exec = new Manager();
            DoWork(emp); // employee works and gets pay check
            DoWork(exec); // if virtual and override are used, MANAGER get pay check
                          // however, if you don't override the method, DoWork
                          // will treat the argument as an Employee.
        }
        static void DoWork(Employee emp)
        {
            emp.Work();
            emp.GetPayCheck();
        }
