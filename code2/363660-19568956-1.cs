	/// <summary>
	/// Generic conversion class for converting between values of different units.
	/// </summary>
	/// <typeparam name="TUnitType">The type representing the unit type (eg. enum)</typeparam>
	/// <typeparam name="TValueType">The type of value for this unit (float, decimal, int, etc.)</typeparam>
	/// <remarks>http://stackoverflow.com/questions/7851448/how-do-i-create-a-generic-converter-for-units-of-measurement-in-c
	/// </remarks>
	public abstract class UnitConverter<TUnitType, TValueType> where TValueType : struct, IComparable, IComparable<TValueType>, IEquatable<TValueType>, IConvertible
	{
		/// <summary>
		/// The base unit, which all calculations will be expressed in terms of.
		/// </summary>
		protected static TUnitType BaseUnit;
		/// <summary>
		/// Dictionary of functions to convert from the base unit type into a specific type.
		/// </summary>
		static ConcurrentDictionary<TUnitType, Func<TValueType, TValueType>> ConversionsTo = new ConcurrentDictionary<TUnitType, Func<TValueType, TValueType>>();
		/// <summary>
		/// Dictionary of functions to convert from the specified type into the base unit type.
		/// </summary>
		static ConcurrentDictionary<TUnitType, Func<TValueType, TValueType>> ConversionsFrom = new ConcurrentDictionary<TUnitType, Func<TValueType, TValueType>>();
		/// <summary>
		/// Converts a value from one unit type to another.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <param name="from">The unit type the provided value is in.</param>
		/// <param name="to">The unit type to convert the value to.</param>
		/// <returns>The converted value.</returns>
		public TValueType Convert(TValueType value, TUnitType from, TUnitType to)
		{
			// If both From/To are the same, don't do any work.
			if (from.Equals(to))
				return value;
			// Convert into the base unit, if required.
			var valueInBaseUnit = from.Equals(BaseUnit)
									? value
									: ConversionsFrom[from](value);
			// Convert from the base unit into the requested unit, if required
			var valueInRequiredUnit = to.Equals(BaseUnit)
									? valueInBaseUnit
									: ConversionsTo[to](valueInBaseUnit);
			return valueInRequiredUnit;
		}
		public double ConversionFactor(TUnitType from, TUnitType to)
		{
			return Convert(One(), from, to).ToDouble(CultureInfo.InvariantCulture);
		}
		/// <summary>
		/// Registers functions for converting to/from a unit.
		/// </summary>
		/// <param name="convertToUnit">The type of unit to convert to/from, from the base unit.</param>
		/// <param name="conversionToFactor">a factor converting into the base unit.</param>
		protected static void RegisterConversion(TUnitType convertToUnit, TValueType conversionToFactor)
		{
			if (!ConversionsTo.TryAdd(convertToUnit, v=> Multiply(v, conversionToFactor)))
				throw new ArgumentException("Already exists", "convertToUnit");
			if (!ConversionsFrom.TryAdd(convertToUnit, v => MultiplicativeInverse(conversionToFactor)))
				throw new ArgumentException("Already exists", "convertToUnit");
		}
		static TValueType Multiply(TValueType a, TValueType b)
		{
			// declare the parameters
			ParameterExpression paramA = Expression.Parameter(typeof(TValueType), "a");
			ParameterExpression paramB = Expression.Parameter(typeof(TValueType), "b");
			// add the parameters together
			BinaryExpression body = Expression.Multiply(paramA, paramB);
			// compile it
			Func<TValueType, TValueType, TValueType> multiply = Expression.Lambda<Func<TValueType, TValueType, TValueType>>(body, paramA, paramB).Compile();
			// call it
			return multiply(a, b);
		}
		
		static TValueType MultiplicativeInverse(TValueType b)
		{
			// declare the parameters
			ParameterExpression paramA = Expression.Parameter(typeof(TValueType), "a");
			ParameterExpression paramB = Expression.Parameter(typeof(TValueType), "b");
			// add the parameters together
			BinaryExpression body = Expression.Divide(paramA, paramB);
			// compile it
			Func<TValueType, TValueType, TValueType> divide = Expression.Lambda<Func<TValueType, TValueType, TValueType>>(body, paramA, paramB).Compile();
			// call it
			return divide(One(), b);
		}
		//Returns the value "1" as converted Type
		static TValueType One()
		{
			return (TValueType) System.Convert.ChangeType(1, typeof (TValueType));
		}
	}
