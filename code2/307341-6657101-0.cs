		private int CountOccurrences(string TestString, string TestPattern)
		{
			int PatternCount = 0;
			int SearchIndex = 0;
			if (TestPattern.Length == 0)
				throw new ApplicationException("CountOccurrences: Unable to process because TestPattern has zero length.");
			if (TestString.Length == 0)
				return 0;
			do
			{
				SearchIndex = TestString.IndexOf(TestPattern, SearchIndex);
				if (SearchIndex >= 0)
				{
					++PatternCount;
					SearchIndex += TestPattern.Length;
				}
			}
			while ((SearchIndex >= 0) && (SearchIndex < TestString.Length));
			return PatternCount;
		}
		private void btnTest_Click(object sender, EventArgs e)
		{
			string TestString1 = "k.k.k.k.k.k.k.k.k.k.k.k";
			string TestPattern1 = "k.k";
			System.Console.WriteLine(CountOccurrences(TestString1, TestPattern1).ToString()); // outputs 6
			System.Console.WriteLine(CountOccurrences(TestString1 + ".k", TestPattern1).ToString()); // still 6
			System.Console.WriteLine(CountOccurrences(TestString1, TestPattern1 + ".").ToString()); // only 5
		}
