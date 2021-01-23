    public static class ExtensionClass
    {
        public static myEnumType GetEnumValue(this string input)
        {
            if (input == myEnumType.strVal_1.ToString())
                return myEnumType.strVal_1;
            return input == myEnumType.strVal_2.ToString() ? myEnumType.strVal_2 : myEnumType.strVal_3;
        }
    }
    List<myEnumType> ValList = new List<myEnumType>(Val.Split(',').Select(p=>p.GetEnumValue())); 
