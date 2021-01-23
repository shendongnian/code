    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumDisplayNameAttribute : Attribute
    {
      public EnumDisplayNameAttribute(string displayName)
      {
        DisplayName = displayName;
      }
        
      public string DisplayName { get; set; }
    }
    
    
    public static string GetDisplayName(this Enum enumType)
    {
      var displayNameAttribute = enumType.GetType()
                                         .GetField(enumType.ToString())
                                         .GetCustomAttributes(typeof(EnumDisplayNameAttribute), false)
                                         .FirstOrDefault() as EnumDisplayNameAttribute;
        
      return displayNameAttribute != null ? displayNameAttribute.DisplayName : Enum.GetName(enumType.GetType(), enumType);
    }
