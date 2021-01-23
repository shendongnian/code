    using System.Linq.Dynamic;
    // ...
    Dictionary<string, string> searchParams = new Dictionary<string,string>();
    
    // EmployeeID is an int column
    searchParams.Add("EmployeeID", "78");
    
    // EmpType is a varchar column. For strings and chars you'll have to use escaped quotes
    searchParams.Add("EmpType", "\"my emp type\"");
    
    IQueryable<Employee> query = context.Employees;
    foreach (KeyValuePair<string, string> keyValuePair in searchParams)
    {
        query = query.Where(string.Format("{0} = {1}", keyValuePair.Key,  keyValuePair.Value));
    }
    Employee employee = query.SingleOrDefault();
    // - or -
    List<Employee> employees = query.ToList();
