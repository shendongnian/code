    // your external dependency
	public class Period
	{
    	public DateTime Start { get; set; }
    	public DateTime End { get; set; }
    	public int Count { get; set; }
    	public string Foo { get; set; }
	}
    // your copycat with only the properties you really need
	public class Periodic
	{
    	public DateTime Start { get; set; }
    	public DateTime End { get; set; }
	}
	
	public class Tempo
	{
        public Periodic Period { get; set; }
        public int Value { get; set; }
	}
	public static void Main()
	{
		var period = new Period{Count = 1, Foo = "bar", Start = DateTime.Now, End = DateTime.Now.AddDays(1)};
		var tempo = new Tempo{Value = 1, Period = new Periodic {Start = period.Start, End = period.End} };
		
        Console.WriteLine(JsonConvert.SerializeObject(tempo));
	}
