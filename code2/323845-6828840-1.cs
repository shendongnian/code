    public static string GetDescription(this Enum value)
            {
                var entries = value.ToString().Split(FlagEnumSeparatorCharacter);
    
                var description = new string[entries.Length];
    
                for (var i = 0; i < entries.Length; i++)
                {
                    var fieldInfo = value.GetType().GetField(entries[i].Trim());
                    var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                    description[i] = (attributes.Length > 0) ? attributes[0].Description : entries[i].Trim();
                }
    
                return String.Join(", ", description);
            }
    public static int GetValue(this Enum value)
        {
            return (int)value.GetType().GetField(value.ToString()).GetRawConstantValue();
        }
        public static T ToEnum<T>(this string value)
        {
            if (typeof(T).BaseType.Name != typeof(Enum).Name)
            {
                throw new Exception("Not an enum");
            }
            return (T)Enum.Parse(typeof(T), value, true);
        }
        public static T ToEnum<T>(this int value)
        {
            if (typeof(T).BaseType.Name != typeof(Enum).Name)
            {
                throw new Exception("Not an enum");
            }
            return (T)Enum.ToObject(typeof(T), value);
        }
