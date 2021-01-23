    using System.Linq;
    
    class Helper {
      public static string GetInitParamsString() {
        return String.Join(",", Application.Current.Host.InitParams.Select (item => item.Key + "=" + item.Value))
      }
    }
