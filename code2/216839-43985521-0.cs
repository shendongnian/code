    public static class MyClass
        {
            private static string _path = ConfigurationManager.AppSettings["FilePath"];
            private static List<string> _list;
    
            static MyClass()
            {
                _list = new List<string>();
                foreach (string l in File.ReadAllLines(_path))
                    _list.Add(l);
            }
            public static List<string> GetList()
            {
                return _list;
            }
        }
