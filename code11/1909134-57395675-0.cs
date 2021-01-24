	private List<EmployeeViewModel> GetTestData(string filePath)
	{
		List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
		using (StreamReader file = new StreamReader(filepath))
		{
			// Read all records from the textfile
			string[] Lines = System.IO.File.ReadAllLines(filepath);
			//Separate data and assign
			foreach (string line in Lines)
			{
				employees.Add(ParseAsEmployeeModel(line));
			}
		}
		
        // Will return an empty array when no records are available
        // Depending on use case a null may be preferable
		return employees;
	}
	private EmployeeViewModel ParseAsEmployeeModel(string csvRecord)
	{
		string[] L = line.Split(',');
		string Name = L[0];
		string Surname = L[1];
		DateTime Birthdate = DateTime.Parse(L[2]); // TODO : error checking to ensure date is valid
		int EmpNum = Convert.ToInt32(L[3]); // TODO: You are losing leading zeros - is this correct?
		int Salary = Convert.ToInt32(L[4]);
		string Role = L[5];
		string Reports = L[6];
		return new EmployeeViewModel(Name, Surname, Birthdate, EmpNum, Salary, Role, Reports);
	}
