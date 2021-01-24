     public static object GetMyCustomProperty(this Type type,string member = "")
        {
            if (type == null)
                return "";
            MemberInfo[] memInfo = type.GetMember(member);
            if (memInfo.Length <= 0) return member;
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(MyCustomPropertyAttribute), false);
            if (!attrs.Any())
                return null;
            var result = ((MyCustomPropertyAttribute)attrs[0]);
      return result.customName;
     }
