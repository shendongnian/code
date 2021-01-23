        public static bool Test<T>()
		{
			var valid = true;
			foreach (var property in typeof(T).GetProperties())
			{
				var accessor = property.GetAccessors()[0];
				if (accessor.IsVirtual)
					continue;
				Console.WriteLine("Member " + typeof(T).Name + "." + property.Name + " is not virtual");
				valid = false;
			}
			return valid;
		}
