        private static string GetMembersAsString(object @this, MemberInfo[] members)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < members.Length; i++)
            {
                var member = members[i];
                if (i != 0) sb.AppendLine();
                object value;
                switch(member.MemberType) {
                    case MemberTypes.Field:
                        value = ((FieldInfo)member).GetValue(@this);
                        break;
                    case MemberTypes.Property:
                        value = ((PropertyInfo)member).GetValue(@this, null);
                        break;
                    default:
                        throw new NotSupportedException(member.MemberType.ToString());
                }
                string s = value == null ? "[null]" : value.ToString().RemoveAll("00:00:00");
                sb.Append(member.Name).Append(" = ").Append(s);
            }
            return sb.ToString();
        }
        public static String GetPublicPropertiesAsString(this Object @this)
        {
            return GetMembersAsString(@this, @this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance));
        }
        public static String GetFieldsAsString(this Object @this)
        {
            return GetMembersAsString(@this, @this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance));
        }
