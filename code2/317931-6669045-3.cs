		public static bool ValueEquality(object val1, object val2)
		{
			if (!(val1 is IConvertible)) throw new ArgumentException("val1 must be IConvertible type");
			if (!(val2 is IConvertible)) throw new ArgumentException("val2 must be IConvertible type");
			// convert val2 to type of val1.
			var converted2 = Convert.ChangeType(val2, val1.GetType());
			// compare now that same type.
			return val1.Equals(converted2);
		}
