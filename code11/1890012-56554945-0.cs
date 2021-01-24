    public static string ToDisplayString<T>(this T type)
            {
                var enumType = typeof(T);
                var name = Enum.GetName(enumType, type);
                var enumMemberAttribute = ((DisplayAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(DisplayAttribute), true)).Single();
                return enumMemberAttribute.Value;
            }
