    int i = 9; //9 is the value for TypeCode.Int32
    if(Enum.IsDefined(typeof(TypeCode), i))
    {
    	TypeCode tc = (TypeCode)i;
    	Console.WriteLine(tc);
    }
    else
    	Console.WriteLine("{0} is not defined for System.TypeCode", i);
