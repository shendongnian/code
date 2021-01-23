		public static bool IsIn<T>(this T value, params T[] list)
		{
			foreach (T t in list)
			{
				if (value.Equals(t))
					return true;
			}
			return false;
		}
