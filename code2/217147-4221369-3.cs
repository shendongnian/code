    public class EmployeeList : List<Employee>
    {
        public void Add(string no, string name)
        {
            this.Add(new Employee(no, name));
        }
    }
    var list = new EmployeeList 
    { 
      { "000001", "Peter Pan" }, 
      { "000002", "King Kong"} 
    };
