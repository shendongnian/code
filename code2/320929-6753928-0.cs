		public static class ArgumentHelper
		{
			public static void VerifyNotNull(object theObject)
			{
				if (theObject == null)
				{
					throw new ArgumentNullException();
				}
			}
			public static void VerifyNotNull(params object[] theObjects)
			{
				if (theObjects.Any(o => o == null))
				{
					throw new ArgumentNullException();
				}
			}
		}
