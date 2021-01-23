    using System.Linq.Dynamic;
    // ...
    Dictionary<string, string> searchParams = new Dictionary<string,string>();
    
    searchParams.Add("EmployeeID", "78");
    searchParams.Add("EmpType", "\"my emp type\"");
    
    IQueryable<Employee> query = context.Employees;
    foreach (KeyValuePair<string, string> keyValuePair in searchParams)
    {
        query = query.Where(string.Format("{0} = {1}", keyValuePair.Key,  keyValuePair.Value));
    }
    List<Employee> employees = query.ToList();
