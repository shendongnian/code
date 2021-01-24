	class Program
	{
		static void Main(string[] args)
		{
			ApiRecord a = new ApiRecord("0,1,2,3,4,5".Split(','));
			Console.WriteLine(JsonConvert.SerializeObject(a));
			Console.ReadLine();
		}
	}
