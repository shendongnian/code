    public class LocalIntern {
    
      private Dictionary<string, string> _intern = new Dictionary<string, string>();
    
      public string Intern(string value) {
        if (_intern.ContainsKey(value)) {
          return _intern[value];
        } else {
          _intern.Add(value, value);
          return value;
        }
      }
    
    }
