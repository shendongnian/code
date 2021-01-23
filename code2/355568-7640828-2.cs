	public class DTO
	{
		public string ClientIP { get; set; }
		public string ClientSession { get; set; }
		public string ServiceName { get; set; }
		public string HostIP { get; set; }
		public string HostSession { get; set; }
	}
	static void Main(string[] args)
	{
		String input = "123.45.67.890-1292 connected to EDS via 10.98.765.432-4300.";
		String[] splits = input.Split(new char[] { ' ' });
		DTO obj = new DTO();
		for (int i = 0; i < splits.Length; ++i) 
		{
			switch (i) 
			{
				// connected
				case 1:
				// to
				case 2:
				// via 
				case 4:
					{
						break;
					}
					
				// 123.45.67.890-1292
				case 0:
					{
						
						obj.ClientIP = splits[i].Split(new char[] { '-' })[0];
						obj.ClientSession = splits[i].Split(new char[] { '-' })[1];
						break;
					}
				// EDS
				case 3:
					{
						obj.ServiceName = splits[i];
						break;
					}
				// 10.98.765.432-4300.
				case 5:
					{
						obj.HostIP = splits[i].Split(new char[] { '-' })[0];
						obj.HostSession = splits[i].Split(new char[] { '-' })[1];
						break;
					}
			}
		}
		Console.ReadKey();	
	}
