			try
			{
				Assembly.Load("System");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			Console.WriteLine(AppDomain.CurrentDomain.GetAssemblies().Any(
			assembly => assembly.FullName.StartsWith("System")));
			Console.ReadLine();
