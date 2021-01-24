    public class Employee {
      public int EmployeeNumber;
      public string Name;    
      public string Department;
      public int MonthlyScore;
    }
    // read your file and load data into your collection here
    List<Employee> employeeList; 
    employeeList.GroupBy(x => x.Department)
    .OrderByDesc(x => x.MonthlyScore).ToList()
    .ForEach(x => {
       Console.WriteLine(x.Key);
       foreach (string item in x.Take(5)) {
         Console.WriteLine(item.EmployeeNumber);
         Console.WriteLine(item.Department);
         Console.WriteLine(item.MonthlyScore);
       }
    });
