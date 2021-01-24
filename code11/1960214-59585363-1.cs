    public class DirectReport
    {
        public string EmployeeId { get; set; }
        public string ReportsTo { get; set; }
    }
    public static List<string> ReportsTo(List<DirectReport> list, string employeeId)
    {
        List<string> reportsTo = new List<string>();
        var managers = list.Where(x => x.EmployeeId.Equals(employeeId)).Select(x => x.ReportsTo).ToList();
        if (managers != null && managers.Count > 0)
            foreach (string manager in managers) { 
                reportsTo.Add(manager);
                reportsTo.AddRange(ReportsTo(list, manager));
            }
            
        return reportsTo;
    }
and you would use the above in main like,
    List<DirectReport> list = new List<DirectReport>()
    {
        new DirectReport(){ EmployeeId = "B001", ReportsTo = "A001" },
        new DirectReport(){ EmployeeId = "B002", ReportsTo = "A001" },
        new DirectReport(){ EmployeeId = "B003", ReportsTo = "A002" },
        new DirectReport(){ EmployeeId = "B004", ReportsTo = "A003" },
        new DirectReport(){ EmployeeId = "C001", ReportsTo = "B001" },
        new DirectReport(){ EmployeeId = "C001", ReportsTo = "B003" },
        new DirectReport(){ EmployeeId = "C002", ReportsTo = "B002" },
              
    };
    var reportsTo = ReportsTo(list, "C001");
    Console.WriteLine(string.Join(Environment.NewLine, reportsTo));
**Output**
B001
A001
B003
A002
