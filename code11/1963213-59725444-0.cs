	public static void Main()
	{
		dynamic w = new ExpandoObject() { Date = DateTime.Now, Item1 = 30 };
		w.Item2 = 123;
		Console.WriteLine(JsonSerializer.Serialize<dynamic>(w));
	}
	
	class ExpandoObject
    {
        public DateTimeOffset Date { get; set; }
        public int Item1 { get; set; }
        public int Item2 { get; set; }
    }
