    static void Main(string[] args)
		{
			try
			{
				try
				{
					throw new ApplicationException("A");
				}
				finally
				{
					throw new ApplicationException("B");
				}
			}
			catch (Exception e)
			{
				
				Console.WriteLine(e.Message);
			}
			Console.Read();
		}
