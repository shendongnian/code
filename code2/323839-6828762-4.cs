    public enum ISO639Code       
    { 
      [Description("af")]
      Afrikaans
    }
    public static class EnumExtensions
    {
        // Extension method to read Description value
        public static string GetDescription(this Enum currentEnum)
        {
             var fi = currentEnum.GetType().GetField(currentEnum.ToString()); 
             var da = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute)); 
             return da != null ? da.Description : currentEnum.ToString();
         } 
    }
    // **How-to read it**
    ISO639Code isoCode = ISO639Code.Afrikaans;
    
    // this will returns "af"
    string isoDescription = isoCode.GetDescription(); 
    
