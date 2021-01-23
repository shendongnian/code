    interface IConvertToString {
      string Convert();
    }
    
    public class Mock : IConvertToString {
      public string Convert() {
        return "ok";
      }
    }
    
    public static T GetValue<T>(T o) where T : IConvertToString {
      return o.ConvertToString();
    }
