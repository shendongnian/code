    [Test]
		public void TrueOnNumberyStringRegex()
		{
			var sources = new[] { "1232", "4567" };
			var isNumber = new Regex(@"^\d+$");
			foreach (var source in sources)
			{
				Assert.IsTrue(isNumber.IsMatch(source));
			}
		}
		[Test]
		public void FalseOnNumberyStringRegex()
		{
			var sources = new[] { "test1", "test", "tes3t", "2323k" };
			var isNumber = new Regex(@"^\d+$");
			foreach (var source in sources)
			{
				Assert.IsFalse(isNumber.IsMatch(source));
			}
		}
