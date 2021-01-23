    public class EmployeeList : List<Employee>
    {
        public void Add(string no, string name)
        {
            
        }
    }
    var list = new EmployeeList 
    { 
      { "000001", "Peter Pan" }, 
      { "000002", "King Kong"} 
    };
