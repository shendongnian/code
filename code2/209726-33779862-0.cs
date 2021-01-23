	internal static class MyResourcesHolder
	{
		private static Image _i1;
		private static Image _i2;
		private static Image _i3;
		private static Image _i4;
		private static Image _i5;
		public static Image MyImage01 => _i1 ?? (_i1 = Resources.MyImage01);
		public static Image MyImage02 => _i2 ?? (_i2 = Resources.MyImage02);
		public static Image MyImage03 => _i3 ?? (_i3 = Resources.MyImage03);
		public static Image MyImage04 => _i4 ?? (_i4 = Resources.MyImage04);
		public static Image MyImage05 => _i5 ?? (_i5 = Resources.MyImage05);
	}
