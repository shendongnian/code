	public class EmployeeViewModel
	{
		public string _Name { get; set; }
		public string _Surname { get; set; }
		public DateTime _Birthdate { get; set; }
		public int _EmpNum { get; set; }
		public int _Salary { get; set; }
		public string _Role { get; set; }
		public string _Reports { get; set; }
		public EmployeeViewModel(string name, string surname, DateTime birthdate, int empnum, int salary, string role, string reports)
		{
			_Name = name;
			_Surname = surname;
			_Birthdate = birthdate;
			_EmpNum = empnum;
			_Salary = salary;
			_Role = role;
			_Reports = reports;
		}
	}
