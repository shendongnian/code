    public class Employee
    {
        public int Id { get; set; }
        public String EmployeeName { get; set; }
        #region FK properties
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
        #endregion
    }
