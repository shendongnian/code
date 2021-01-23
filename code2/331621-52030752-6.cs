    public class NumeralGeneratorTests
	{
		private readonly ITestOutputHelper _output;
		public NumeralGeneratorTests(ITestOutputHelper output)
		{
			_output = output;
		}
		[Theory]
		[InlineData(1, "I")]
		[InlineData(2, "II")]
		[InlineData(3, "III")]
		[InlineData(4, "IV")]
		[InlineData(5, "V")]
		[InlineData(6, "VI")]
		[InlineData(7, "VII")]
		[InlineData(8, "VIII")]
		[InlineData(9, "IX")]
		[InlineData(10, "X")]
		[InlineData(11, "XI")]
		[InlineData(15, "XV")]
		[InlineData(1490, "MCDXC")]
		[InlineData(1480, "MCDLXXX")]
		[InlineData(1580, "MDLXXX")]
		[InlineData(1590, "MDXC")]
		[InlineData(1594, "MDXCIV")]
		[InlineData(1294, "MCCXCIV")]
		[InlineData(3999, "MMMCMXCIX")]
		[InlineData(4000, "I\u0305V\u0305")]
		[InlineData(4001, "I\u0305V\u0305I")]
		[InlineData(5002, "V\u0305II")]
		[InlineData(10000, "X\u0305")]
		[InlineData(15000, "X\u0305V\u0305")]
		[InlineData(15494, "X\u0305V\u0305CDXCIV")]
		[InlineData(2468523, "M\u0305M\u0305C\u0305D\u0305L\u0305X\u0305V\u0305MMMDXXIII")]
		public void ToNumeral(int number, string expected)
		{
			var sw = Stopwatch.StartNew();
			var actual = NumeralGenerator.ToNumeral(number);
			sw.Stop();
			_output.WriteLine(sw.ElapsedMilliseconds.ToString());
			Assert.Equal(expected, actual);
		}
	}
