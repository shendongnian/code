    public static Type GetType(TypeCode code)
        {         
            return Type.GetType("System." + Enum.GetName(typeof(TypeCode), code));
        }
 
