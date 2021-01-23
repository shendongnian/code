		public delegate string GroupFieldDelegate(Employee e);
		private static string CategoryGrouping(Employee e)
		{
			return e.Category;
		}
		static Dictionary<string, List<Employee>> Group(List<Employee> Data, GroupFieldDelegate Grouping)
		{
			Dictionary<string, List<Employee>> result = new Dictionary<string, List<Employee>>();
			foreach (Employee e in Data)
			{
				string Category = Grouping(e);
				if (result.ContainsKey(Category)) result[Category].Add(e);
				else (result[Category] = new List<Employee>()).Add(e);c
			}
			return result;
		}
