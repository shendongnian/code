    public static class EnumEx {
      public static Type GetUnderlyingType(Type enumType) {
        if (!enumType.IsEnum) throw new ArgumentException();
        if (enumType.GetCustomAttributes(typeof(CharAttribute), false).Length > 0) {
          return typeof(char);
        }
        return Enum.GetUnderlyingType(enumType);
      }
      public static object ConvertToUnderlyingType(object enumValue) {
        return Convert.ChangeType(enumValue,
          GetUnderlyingType(enumValue.GetType()));
      }
    }
