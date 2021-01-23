    public class SessionStorageService :  IStorageService 
    { 
      public void SetValue(string key, object value) 
      {
        HttpContext.Current.Session[key] = value; 
      }
      public object GetValue(string key) 
      {
        return HttpContext.Current.Session[key]; 
      }
    }
