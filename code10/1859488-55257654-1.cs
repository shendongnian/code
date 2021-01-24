    public class EmployeeDetails
    {
        public string EmployeeId { get; set; }
        public string DesignationId { get; set; }
    }
    public class EmployeeDetailsDisplay
    {
        public EmployeeDetailsDisplay()
        {
            details = new List<EmployeeDetails>();
        }
        public List<EmployeeDetails> details { get; set; }
    }
