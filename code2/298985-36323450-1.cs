		[TestMethod]
		public void TestSizeParse()
		{
			var s1 = new Size(1024, 768);
			var s1Str = s1.ToString();
			Size s2 = s1Str.Parse();
			Assert.AreEqual(s1.Width, s2.Width);
			Assert.AreEqual(s1.Height, s2.Height);
			Assert.AreEqual(s1, s2, "s1 and s2 are supposed to be equal");
		}
