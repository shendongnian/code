      public interface IIdentifierFormatter
      {
        string FormatText(string text);
      }
    
      public class UnformattedIdenifierFormatter : IIdentifierFormatter
      {
        public string FormatText(string text)
        {
          return text;
        }
      }
    
      public class CamelCaseIdenifierFormatter : IIdentifierFormatter
      {
        public string FormatText(string text)
        {
          // Camel case formatting here
          return text;
        }
      }
    
      public class ProperCaseIdenifierFormatter : IIdentifierFormatter
      {
        public string FormatText(string text)
        {
          // Proper case formatting here
          return text;
        }
      }
