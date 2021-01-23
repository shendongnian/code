            foreach (var c in from object c in HttpContext.Cache where ((System.Collections.DictionaryEntry)c).Key.ToString().Contains("__MVCSITEMAP") select c)
            {
                HttpContext.Cache.Remove(((System.Collections.DictionaryEntry)c).Key.ToString());
                break;
            }
