      public static class YesNo{
           public static string GetYesOrNo(this bool boolean)
           {
               var dictionary = boolean ? _yesDictionary : _noDictionary;
               if(dictionary.ContainsKey(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName))
               {
                   return dictionary[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
               }
               return boolean ? DEFAULT_YES : DEFAULT_NO;
           }
          const string DEFAULT_YES = "yes";
          const string DEFAULT_NO = "no";
          
          private static readonly Dictionary<string, string> _yesDictionary = new Dictionary<string, string>
                                                                                  {
                                                                                      {"en","yes"},
                                                                                      {"de", "ja"},
                                                                                      {"es", "si"}
                                                                                  };
          private static readonly Dictionary<string, string> _noDictionary = new Dictionary<string, string>
                                                                                 {
                                                                                     {"en", "no"},
                                                                                     {"de", "nein"},
                                                                                     {"es", "no"}
                                                                                 };
      }
