		/// <summary>
		/// Test for ToSet
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ToSetOnNullThrows()
		{
			List<string> list = null;
			var target = list.ToHashSet();
		}
