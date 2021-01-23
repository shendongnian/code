    public class Test
    {
        public static string GetValue(string key)
        {
            string value = string.Empty;
            if (HttpContext.Current.Session["FROMDATA"] != null)
            {
                Dictionary<string, string> form = (Dictionary<string, string>)HttpContext.Current.Session["FROMDATA"];
                if(form.ContainsKey(key))
                    value = form[key];
            }
            return value;
        }
    }
