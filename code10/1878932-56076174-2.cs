    using System.Collections.Generic;
    using System.Linq;
  
      public class SpreadsheetMapper
        {
    
            private static readonly Dictionary<string, string> dict = new Dictionary<string, string>();
    
            public static void Map(string key, string value)
            {
                if(key==String.Empty)
                {
                   throw new ArgumentException();
                }
                if (dict.ContainsKey(key))
                {
                    dict[key] = value;
                }
                else
                {
                    if (value == string.Empty)
                    {
                        dict.Remove(key);
                    }
                    else
                    {
                        dict.Add(key, value);
                    }
                }
            }
    
            public static string Value(string key)
            {
                if (dict.ContainsKey(key) & key!=String.Empty)
                {
                    return dict[key];
                }
            }
    
            public static IEnumerable<string> Keys(string value)
            {
                return dict.Where(x => x.Value == value).Select(x=> x.Key);
            }
        }
    SpreadsheetMapper.Map("some key 1", "some value")
    SpreadsheetMapper.Value("some key")
    etc...
