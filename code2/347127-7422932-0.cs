    /// <summary>
    /// This attribute is used to represent a string value
    /// for a value in an enum.
    /// </summary>
    public class StringValueAttribute : Attribute {
    
        #region Properties
    
        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value) {
            this.StringValue = value;
        }
    
        #endregion
    
    }
    
    public static class MyExtension
    {
        public static string GetStringValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();
    
            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());
    
            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];
    
            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    
        public static String[] GetEnumNames(Type t)
        {
            Array enumValueArray= Enum.GetValues(t);
    
            string[] enumStrings = new String[enumValueArray.Length];
            for(int i = 0; i< enumValueArray.Length; ++i)
            {
                enumStrings[i] = GetStringValue((test)enumValueArray.GetValue(i));
            }
    
            return enumStrings;
        }
    }
    
    enum test
    {
        [StringValue("test ONE")]
        test1,
        [StringValue("test TWO")]
        test2
    }
