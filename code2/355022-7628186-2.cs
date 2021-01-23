    public static object[] GetValues(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type '" + enumType.Name + "' is not an enum");
            }
    
            List<object> values = new List<object>();
    
            var fields = from field in enumType.GetFields()
                         where field.IsLiteral
                         select field;
    
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(enumType);
                values.Add(value);
            }
    
            return values.ToArray();
        }
