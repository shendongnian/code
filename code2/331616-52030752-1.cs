    public interface INumeralBand
	{
		int Value { get; }
		string Numeral { get; }
		void Process(int number, StringBuilder numerals);
	}
