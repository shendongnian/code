        public static bool Test<T>()
		{
			var valid = true;
			var members = typeof(T).GetProperties().Where(c => c.CanRead).Select(c => c.GetGetMethod());
			foreach (var member in members)
			{
				if (!member.IsVirtual)
				{
					Console.WriteLine("Member " + member.Name + "." + member.Name + " is not virtual");
					valid = false;
				}
			}
			return valid;
		}
