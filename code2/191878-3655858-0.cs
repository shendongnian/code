    class YourRow
    {
        public int level {get; set;}
        public int PeckingOrder {get; set;}
        ...
    }
    using (var db = new LinqDataContext())
    {
        var list = db.ExecuteQuery<YourRow>(
    @"
    WITH n(level, PeckingOrder, Department, EmployeeName, HigherDepartment) AS 
        (SELECT 1, PeckingOrder, Department, EmployeeName, HigherDepartment
    ...
    ";
    }
