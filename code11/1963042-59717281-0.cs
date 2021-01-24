        public static bool IsEqual<T>(this T value, T other, ComparisonConfig config = null)
		{
			var comparer = new CompareLogic();
			if (config != null) comparer.Config = config;
			var comparisonResult = comparer.Compare(value, other);
			return comparisonResult.AreEqual;
		}
