    public static IDictionary<TKey, TEnum> GetReverseEnumLookup<TEnum, TKey, TAttribute>(Func<TAttribute, TKey> selector, IEqualityComparer<TKey> comparer = null)
        where TEnum: struct, IConvertible // pre-C#7.3
        // where TEnum : System.Enum // C#7.3+
        where TAttribute: System.Attribute
    {
		// use the default comparer for the dictionary if none is specified
        comparer = comparer ?? EqualityComparer<TKey>.Default;
		
		// construct a lookup dictionary with the supplied comparer
        Dictionary<TKey, TEnum> values = new Dictionary<TKey, TEnum>(comparer);
		
		// get all of the enum values
        Type enumType = typeof(TEnum);
        var enumValues = typeof(TEnum).GetEnumValues().OfType<TEnum>();
		
		// for each enum value, get the corresponding field member from the enum
        foreach (var val in enumValues)
        {
            var member = enumType.GetMember(val.ToString()).First();
			
			// if there is an attribute, save the selected value and corresponding enum value in the dictionary
            var attr = member.GetCustomAttribute<TAttribute>();
            if (attr != null) 
            {
                values[selector(attr)] = val;
            }
        }
        return values;
    }
	
