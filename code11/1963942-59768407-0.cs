    public class AbstractTest : TimeLength
    {
        public AbstractTest(string employeeCode, string employee, Holiday typeOfHoliday, DateTime startDate, DateTime endDate) : base(startDate, endDate, "")
        {
            TypeOfHoliday = typeOfHoliday;
            Employee = employee;
            EmployeeCode = employeeCode;
        }
        public string EmployeeCode { get; set; }
        public string Employee { get; set; }
        public Holiday TypeOfHoliday { get; set; }
        public bool HolidayValidation(Holiday typeOfHoliday)
        {
            return Days() > (int)typeOfHoliday;
        }
    }
