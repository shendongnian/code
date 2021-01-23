      using System.Data.Entity.Design.PluralizationServices;
      using System.Reflection;
      public static class Strings
      {
        private static PluralizationService pluralizationService = PluralizationService.CreateService(System.Globalization.CultureInfo.CurrentUICulture);
        public static string Pluralize(this MemberInfo memberInfo)//types, propertyinfos, ect
        {
          return Pluralize(memberInfo.Name.StripEnd());
        }
    
        public static string Pluralize(this string name)
        {
          return pluralizationService.Pluralize(name); // remove EF type suffix, if any
        }
    
        public static string StripEnd(this string name)
        {
          return name.Split('_')[0];
        }
      }
