    [Test]
		public void FalseOnStringyString()
		{
			var sources = new []{"test1", "test", "tes3t", "2323k"};
			foreach (var source in sources)
			{
				int parsed;
				Assert.IsFalse(int.TryParse(source, NumberStyles.Any, CultureInfo.InvariantCulture, out parsed));
			}
		}
		[Test]
		public void TrueOnNumberyString()
		{
			var sources = new[] { "1232", "4567" };
			foreach (var source in sources)
			{
				int parsed;
				Assert.IsTrue(int.TryParse(source, NumberStyles.Any, CultureInfo.InvariantCulture, out parsed));
			}
		}
