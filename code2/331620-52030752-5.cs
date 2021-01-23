    public class NumeralBandTests
	{
		private Mock<INumeralBand> _nextBand;
		private Mock<INumeralBand> _negatedBy;
		private StringBuilder _stringBuilder;
		public NumeralBandTests()
		{
			_stringBuilder = new StringBuilder();
			_nextBand = new Mock<INumeralBand>();
			_negatedBy = new Mock<INumeralBand>();
		}
		[Fact]
		public void Process_NegateAndStop()
		{
			var numeral = new NumeralBand(10, "X", _negatedBy.Object);
			_negatedBy.Setup(x => x.Value).Returns(1);
			_negatedBy.Setup(x => x.Numeral).Returns("I");
			numeral.Process(9, _stringBuilder);
			Assert.Equal("IX", _stringBuilder.ToString());
			_nextBand.Verify(x => x.Process(It.IsAny<int>(), It.IsAny<StringBuilder>()), Times.Never);
		}
		[Fact]
		public void Process_Exact()
		{
			var numeral = new NumeralBand(10, "X", _negatedBy.Object);
			_negatedBy.Setup(x => x.Value).Returns(1);
			_negatedBy.Setup(x => x.Numeral).Returns("I");
			numeral.Process(10, _stringBuilder);
			Assert.Equal("X", _stringBuilder.ToString());
			_nextBand.Verify(x => x.Process(It.IsAny<int>(), It.IsAny<StringBuilder>()), Times.Never);
		}
		[Fact]
		public void Process_NegateAndContinue()
		{
			var numeral = new NumeralBand(50, "L", _negatedBy.Object);
			numeral.ConfigureNext(_nextBand.Object);
			_negatedBy.Setup(x => x.Value).Returns(10);
			_negatedBy.Setup(x => x.Numeral).Returns("X");
			numeral.Process(54, _stringBuilder);
			Assert.Equal("L", _stringBuilder.ToString());
			_nextBand.Verify(x => x.Process(4, _stringBuilder), Times.Once);
		}
	}
