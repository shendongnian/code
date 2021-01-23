    public void TestDB() {
            demoEntities de = new demoEntities();
            var q = firstPart(de, d => false);
            foreach(var item in q.Where(e => e.EmployeeID == 1)){
            
            }
        }
        public IQueryable<Employee> firstPart(demoEntities de, Func<Department, bool> departmentFilter) {
            return from e in de.Employees
                   where departmentFilter(e.Department)
                   select e;
        }
