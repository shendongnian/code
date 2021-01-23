	private class EmployeeMetadata
	{
		//the type HAS to match what your have in your Employee class
		[Required]
		public string Name { get; set; }
	}
	public partial class Employee : EmployeeMetadata
	{
	}
