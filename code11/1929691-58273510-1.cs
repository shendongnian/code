    public static void Main()
	{
		List<InputData> listOne = new List<InputData>
		{
			new InputData("63245-8", 10),
			new InputData("08657-5", 100),
			new InputData("29995-0", 500)
		};
		
		List<InputData> listTwo = new List<InputData>
		{
			new InputData("63245-8", 100),
			new InputData("67455-1", 100),
			new InputData("44187-10", 50)
		};
		
		Dictionary<string, InputData> dictOne = CreateDictionary(listOne);		
		Dictionary<string, InputData> dictTwo = CreateDictionary(listTwo);
		
		List<ResultData> result = new List<ResultData>();
		
		result.AddRange(ProcessData(listOne, dictTwo, "deleted"));
		result.AddRange(ProcessData(listTwo, dictOne, "new"));
		
		foreach(var item in result){
			Console.WriteLine($"Serial: {item.Serial}, Amount: {item.Amount}, Status: {item.Status}");
		}
	}
