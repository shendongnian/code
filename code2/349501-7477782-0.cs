	public static class Flags
	{
		/// <summary>
		/// Checks if the type has any flag of value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool HasAny<T>(this System.Enum type, T value)
		{
			try
			{
				return (((int) (object) type & (int) (object) value) != 0);
			}
			catch
			{
				return false;
			}
		}
		/// <summary>
		/// Checks if the value contains the provided type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool Has<T>(this System.Enum type, T value)
		{
			try
			{
				return (((int)(object)type & (int)(object)value) == (int)(object)value);
			}
			catch
			{
				return false;
			}
		}
		/// <summary>
		/// Checks if the value is only the provided type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool Is<T>(this System.Enum type, T value)
		{
			try
			{
				return (int)(object)type == (int)(object)value;
			}
			catch
			{
				return false;
			}
		}
		/// <summary>
		/// Appends a value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static T Add<T>(this System.Enum type, T value)
		{
			try
			{
				return (T)(object)(((int)(object)type | (int)(object)value));
			}
			catch (Exception ex)
			{
				throw new ArgumentException(
					string.Format(
						"Could not append value from enumerated type '{0}'.",
						typeof(T).Name
						), ex);
			}
		}
		/// <summary>
		/// Appends a value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static void AddTo<T>(this System.Enum type, ref T value)
		{
			try
			{
				value = (T)(object)(((int)(object)type | (int)(object)value));
			}
			catch (Exception ex)
			{
				throw new ArgumentException(
					string.Format(
						"Could not append value from enumerated type '{0}'.",
						typeof(T).Name
						), ex);
			}
		}
		/// <summary>
		/// Removes the value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static T Remove<T>(this System.Enum type, T value)
		{
			try
			{
				return (T)(object)(((int)(object)type & ~(int)(object)value));
			}
			catch (Exception ex)
			{
				throw new ArgumentException(
					string.Format(
						"Could not remove value from enumerated type '{0}'.",
						typeof(T).Name
						), ex);
			}
		}
		/// <summary>
		/// Removes the value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static void RemoveFrom<T>(this System.Enum type, ref T value)
		{
			try
			{
				value = (T)(object)(((int)(object)type & ~(int)(object)value));
			}
			catch (Exception ex)
			{
				throw new ArgumentException(
					string.Format(
						"Could not remove value from enumerated type '{0}'.",
						typeof(T).Name
						), ex);
			}
		}
	}
