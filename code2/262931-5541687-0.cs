		public static bool TryParse<TType>(this object obj, out TType result) 
		{
			try
			{
				result = (TType)Convert.ChangeType(obj, typeof(TType));
				return true;
			}
			catch
			{
				result = default(TType);
				return false;
			}
		}
		public static TType Parse<TType>(this object obj) where TType : struct
		{
			try
			{
				return (TType)Convert.ChangeType(obj, typeof(TType));
			}
			catch
			{
				throw new InvalidCastException("Cant cast object to " + typeof(TType).Name);
			}
		}
