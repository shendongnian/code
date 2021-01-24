    public class TypeSafeEnumConverter
    {
        public static object ConvertToTypeSafeEnum(string typeName, string value)
        {
            switch (typeName)
            {
                case "BirdType":
                    return BirdType.Parse(value);
                //case "SomeOtherType": // other type safe enums
                //    return // some other type safe parse call
                default:
                    return null;
            }
        }
    }
