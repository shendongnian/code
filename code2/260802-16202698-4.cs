	/// <summary>
	/// Since all dates in the DB are stored as UTC, this converts dates to the local time using the Windows time zone settings.
	/// </summary>
	public static class AllDateTimesAsUTC
	{
		/// <summary>
		/// Specifies that an object's dates are coming in as UTC.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static T AllDatesAreUTC<T>(this T obj)
		{
			if (obj == null)
			{
				return default(T);
			}
			IterateDateTimeProperties(obj);
			return obj;
		}
		private static void IterateDateTimeProperties(object obj)
		{
			if (obj == null)
			{
				return;
			}
			var properties = obj.GetType().GetProperties();
			//Set all DaetTimeKinds to Utc
			foreach (var prop in properties)
			{
				var t = prop.PropertyType;
				if (t == typeof(DateTime) || t == typeof(DateTime?))
				{
					SpecifyUtcKind(prop, obj);
				}
				else if (t.IsEnumerable())
				{
					var vals = prop.GetValue(obj, null);
					if (vals != null)
					{
						foreach (object o in (IEnumerable)vals)
						{
							IterateDateTimeProperties(o);
						}
					}
				}
				else
				{
					var val = prop.GetValue(obj, null);
					if (val != null)
					{
						IterateDateTimeProperties(val);
					}
				}
			}
			//properties.ForEach(property => SpecifyUtcKind(property, obj));
			return; // obj;
		}
		private static void SpecifyUtcKind(PropertyInfo property, object value)
		{
			//Get the datetime value
			var datetime = property.GetValue(value, null);
			DateTime output;
			//set DateTimeKind to Utc
			if (property.PropertyType == typeof(DateTime))
			{
				output = DateTime.SpecifyKind((DateTime)datetime, DateTimeKind.Utc);
			}
			else if (property.PropertyType == typeof(DateTime?))
			{
				var nullable = (DateTime?)datetime;
				if (!nullable.HasValue) return;
				output = (DateTime)DateTime.SpecifyKind(nullable.Value, DateTimeKind.Utc);
			}
			else
			{
				return;
			}
			Debug.WriteLine("     ***** Converted date from {0} to {1}.", datetime, output);
			datetime = output.ToLocalTime();
			//And set the Utc DateTime value
			property.SetValue(value, datetime, null);
		}
		internal static Type[] ConvertibleTypes = {typeof(bool), typeof(byte), typeof(char),
    typeof(DateTime), typeof(decimal), typeof(double), typeof(float), typeof(int), 
    typeof(long), typeof(sbyte), typeof(short), typeof(string), typeof(uint), 
    typeof(ulong), typeof(ushort)};
		/// <summary>
		/// Returns true if this Type matches any of a set of Types.
		/// </summary>
		/// <param name="types">The Types to compare this Type to.</param>
		public static bool In(this Type type, params Type[] types)
		{
			foreach (Type t in types) if (t.IsAssignableFrom(type)) return true; return false;
		}
		/// <summary>
		/// Returns true if this Type is one of the types accepted by Convert.ToString() 
		/// (other than object).
		/// </summary>
		public static bool IsConvertible(this Type t) { return t.In(ConvertibleTypes); }
		/// <summary>
		/// Gets whether this type is enumerable.
		/// </summary>
		public static bool IsEnumerable(this Type t)
		{
			return typeof(IEnumerable).IsAssignableFrom(t);
		}
		/// <summary>
		/// Returns true if this property's getter is public, has no arguments, and has no 
		/// generic type parameters.
		/// </summary>
		public static bool SimpleGetter(this PropertyInfo info)
		{
			MethodInfo method = info.GetGetMethod(false);
			return method != null && method.GetParameters().Length == 0 &&
				 method.GetGenericArguments().Length == 0;
		}
	}
