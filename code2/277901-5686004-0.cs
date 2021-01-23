    static void HandleEnumValue(Enum v, Enum bits) {
    	ulong enumValue = ToUInt64(v);
    	ulong bitsValue = ToUInt64(bits);
    	bool hasBitsSet = (enumValue & bitsValue) == bitsValue;
    	Console.WriteLine("enum value   = " + v);
    	Console.WriteLine("number value = " + bits);
    	Console.WriteLine("has bits set = " + hasBitsSet);
    }
    internal static ulong ToUInt64(Enum value) {
    	switch (Convert.GetTypeCode(value)) {
    		case TypeCode.SByte:
    		case TypeCode.Int16:
    		case TypeCode.Int32:
    		case TypeCode.Int64:
    			return (ulong) Convert.ToInt64(value);
    		case TypeCode.Byte:
    		case TypeCode.UInt16:
    		case TypeCode.UInt32:
    		case TypeCode.UInt64:
    			return Convert.ToUInt64(value);
    		default:
    			throw new ArgumentOutOfRangeException("value");
    	}
    }
