	public class Employee
	{
		public Employee()
		{
			
		}
		public Employee(int count)
		{
			Employees = new List<Employee>();
			List<Employee> list = Employees as List<Employee>;
			for (int i = 0; i < count; i++)
			{
				list.Add(new Employee());				
			}
		}
		public IEnumerable<Employee> Employees { get; set; }
	}
    class Program
    {
        static void Main(string[] args)
        {
        	IEnumerable<Employee> employees = new Employee[]
        	                                  	{
        	                                  		new Employee(3),
 													                new Employee(2)
        };
        	IEnumerable<Employee> enumerable = employees.Concat(employees.SelectMany(x => x.Employees));
        	Console.WriteLine(enumerable.Count());
        	Console.Read();
        }
    }
