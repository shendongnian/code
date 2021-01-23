    using System.Data.Entity.Design.PluralizationServices;
    public class MyClass
    {
    
    public static string Pluralize(MemberInfo memberInfo)
    {
      return Pluralize(memberInfo.Name);
    }
    
    private static PluralizationService pluralizationService = PluralizationService.CreateService(System.Globalization.CultureInfo.CurrentUICulture);
    public static string Pluralize(string word)
    {
      return pluralizationService.Pluralize(word); 
    }
    
    }
      public static class Strings
      {
        public static string Pluralize(this string word)
        {
          return MyClass.Pluralize(word);
        }
      }
