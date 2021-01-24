    [Table("EmployeeSalary")]
    public class EmployeeSalary
    {
        public EmployeeSalary()
        {
           EmployeeInfo = new HashSet<EmployeeInfo>();
        }
        [Key]
        public Int16 SSID { get; set; }
        ….
        public virtual ICollection<EmployeeInfo> EmployeeInfo { get; set; }
    }
    public class EmployeeInfo
    {
        public Int16 SSID { get; set; }
        ….
        [ForeignKey("SSID")]
        public virtual EmployeeSalary EmployeeSalary { get; set; }    }
    
