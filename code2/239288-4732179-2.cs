     public static string GetValue(string sessionkey,string key)
        {
            string value = string.Empty;
            if (HttpContext.Current.Session[sessionkey] != null)
            {
                Dictionary<string, string> form = (Dictionary<string, string>)HttpContext.Current.Session[sessionkey];
                if(form.ContainsKey(key))
                    value = form[key];
            }
            return value;
        }
