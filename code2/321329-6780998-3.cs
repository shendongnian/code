    // This is the class I used to hold the extensions.
    public static class EnumFunctions
    {
        // Custom GetAttribute Extension - used to pull an attribute out of the enumerations.
        // This code is as per Hunter's answer, except I added the null check.
        public static T GetAttribute<T>(this Enum e) where T : Attribute
        {
            FieldInfo fieldInfo = e.GetType().GetField(e.ToString());
            
            // If the enumeration is set to an illegal value (for example 0,
            // when you don't have a 0 in your enum) then the field comes back null.
            // test and avoid the exception.
            if (fieldInfo != null)
            {
                T[] attribs = fieldInfo.GetCustomAttributes(typeof(T), false) as T[];
                return attribs.Length > 0 ? attribs[0] : null;
            }
            else
            {
                return null;
            }
        }
        // Custom GetKeyValuePairs - returns a List of <int,string> key value pairs with
        // each Enum value along with it's Description attribute.
        // This will only work with a decorated Enum. I've not included or tested what
        // happens if your enum doesn't have Description attributes.
        public static List<KeyValuePair<int, string>> GetKeyValuePairs(this Enum e)
        {
            List<KeyValuePair<int, string>> ret = new List<KeyValuePair<int, string>>();
            foreach (Enum val in Enum.GetValues(e.GetType()))
            {
                ret.Add(new KeyValuePair<int, string>(Convert.ToInt32(val), val.GetAttribute<DescriptionAttribute>().Description));
            }
            return ret;
        }
    }
