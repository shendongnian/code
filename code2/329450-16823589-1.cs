        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            EnumMemberAttribute[] attributes =
                (EnumMemberAttribute[])fi.GetCustomAttributes(
                typeof(EnumMemberAttribute),
                true);
            if (attributes != null && attributes.Length > 0)
                if (attributes[0].Value != null)
                    return attributes[0].Value;
                else
                    return value.ToString();
            else
                return value.ToString();
        }
