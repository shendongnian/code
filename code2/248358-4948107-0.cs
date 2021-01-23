        public static T? GetValue<T>(this DataRow row, string field) where T : struct
		{
			if (row.IsNull(field))
				return new T?();
			else
				return (T?)row[field];
		}
		public static T GetReference<T>(this DataRow row, string field) where T : class
		{
			if (row.IsNull(field))
				return default(T);
			else
				return (T)row[field];
		}
