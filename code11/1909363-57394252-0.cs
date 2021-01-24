    private async Task<IReadOnlyCollection<EmployeeViewModel>> GetTestData()
    {
    
    	var filepath = @"D:\Employees.txt";
    	var employees = new List<EmployeeViewModel>();
    	
    	using(var reader = File.OpenText(filepath))
    	{
    		while(!reader.EndOfStream)
    		{
    			var line = await reader.ReadLineAsync().ConfigureAwait(false);
    			var columns = line.Split(',');
    			var employee = new EmployeeViewModel(columns[0], columns[1], DateTimeOffset.Parse(columns[2], new CultureInfo("de")), int.Parse(columns[3]), int.Parse(columns[4]), columns[5], columns[6]);
    			employees.Add(employee);
    		}
    	}
    	
    	return employees;
    }
    
    public class EmployeeViewModel
    {
    	public string Name { get; }
    	public string Surname { get; }
    	public DateTimeOffset Birthdate { get;  }
    	public int EmpNum { get; }
    	public int Salary { get; }
    	public string Role { get; }
    	public string Reports { get; }
    
    	public EmployeeViewModel(string name, string surname, DateTimeOffset birthdate, int empnum, int salary, string role, string reports)
    	{
    		Name = name;
    		Surname = surname;
    		Birthdate = birthdate;
    		EmpNum = empnum;
    		Salary = salary;
    		Role = role;
    		Reports = reports;
    	}
    }
