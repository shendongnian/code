    public static Type GetActualType(Type type, out bool isNullable)
    {
        Type ult = Nullable.GetUnderlyingType(type);
        if (ult != null)
        {
            isNullable = true;
            return ult;
         }
         isNullable = false;
         return type;
    }
