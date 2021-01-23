    public class NumeralBand : INumeralBand
	{
		private readonly INumeralBand _negatedBy;
		private INumeralBand _nextBand;
		public NumeralBand(int value, string numeral, INumeralBand negatedBy)
		{
			_negatedBy = negatedBy;
			Value = value;
			Numeral = numeral;
		}
		public int Value { get; }
		public string Numeral { get; }
		public void Process(int number, StringBuilder numerals)
		{
			if (ShouldNegateAndStop(number))
			{
				numerals.Append(NegatedNumeral);
				return;
			}
			var numeralCount = Math.Abs(number / Value);
			var remainder = number % Value;
			numerals.Append(string.Concat(Enumerable.Range(1, numeralCount).Select(x => Numeral)));
			if (ShouldNegateAndContinue(remainder))
			{
				NegateAndContinue(numerals, remainder);
				return;
			}
			if (remainder > 0)
				_nextBand.Process(remainder, numerals);
		}
		private string NegatedNumeral => $"{_negatedBy.Numeral}{Numeral}";
		private bool ShouldNegateAndStop(int number) => number == Value - _negatedBy.Value;
		private bool ShouldNegateAndContinue(int number) => number >= Value - _negatedBy.Value;
		private void NegateAndContinue(StringBuilder stringBuilder, int remainder)
		{
			stringBuilder.Append(NegatedNumeral);
			remainder = remainder % (Value - _negatedBy.Value);
			_nextBand.Process(remainder, stringBuilder);
		}
		public T ConfigureNext<T>(T nextBand) where T : INumeralBand
		{
			_nextBand = nextBand;
			return nextBand;
		}
	}
