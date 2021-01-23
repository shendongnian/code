        public static Dictionary<string, string> GetAuthors()
        {
            Dictionary<string, string> _dict = new Dictionary<string, string>();
            PropertyInfo[] props = typeof(Book).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    AuthorAttribute authAttr = attr as AuthorAttribute;
                    if (authAttr != null)
                    {
                        string propName = prop.Name;
                        string auth = authAttr.Name;
                        _dict.Add(propName, auth);
                    }
                }
            }
            return _dict;
        }
