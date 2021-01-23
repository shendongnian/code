    public class FinalBandTests
	{
		[Theory]
		[InlineData(1, "I")]
		[InlineData(2, "II")]
		[InlineData(3, "III")]
		[InlineData(4, "IIII")]
		public void Process(int number, string expected)
		{
			var stringBuilder = new StringBuilder();
			var numeralBand = new FinalBand(1, "I");
			numeralBand.Process(number, stringBuilder);
			Assert.Equal(expected, stringBuilder.ToString());
		}
	}
