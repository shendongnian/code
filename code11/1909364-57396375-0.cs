    public class EmployeeViewModel
    {
    	private readonly string[] validDateFormats =
            {
                "MMM dd, yyyy h:mm tt", "MMM d, yyyy h:mm tt", "MMM dd, yyyy h:mm:ss tt", "MMM d, yyyy h:mm:ss tt",
                "MMM dd, yyyy h:mm tt", "MMM dd, yyyy", "yyyy-MM-dd", "yyyy-M-dd", "yyyy-M-d", "M/dd/yyyy h:mm:ss tt",
                "M/d/yyyy h:mm:ss tt", "M/dd/yyyy h:mm tt", "M/d/yyyy h:mm tt"
            };
    		
    	public string Name { get; set; }
    	public string Surname { get; set; }
    	public DateTime? Birthdate { get; set; }
    	public int EmpNum { get; set; }
    	public int Salary { get; set; }
    	public string Role { get; set; }
    	public string Reports { get; set; }
    
    	public EmployeeViewModel(string name, string surname, string birthdate, int empnum, int salary, string role, string reports)
    	{
    		DateTime outValue;
    		
    		Name = name;
    		Surname = surname;
    		Birthdate = DateTime.TryParseExact(birthdate, validDateFormats, null, System.Globalization.DateTimeStyles.None, out outValue)
                        ? outValue : (DateTime?)null;
    		EmpNum = empnum;
    		Salary = salary;
    		Role = role;
    		Reports = reports;
    	}
    }
