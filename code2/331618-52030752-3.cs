    public class FinalBand : INumeralBand
	{
		public FinalBand(int value, string numeral)
		{
			Value = value;
			Numeral = numeral;
		}
		public int Value { get; }
		public string Numeral { get; }
		public void Process(int number, StringBuilder numerals)
		{
			numerals.Append(new string(Numeral[0], number));
		}
	}
