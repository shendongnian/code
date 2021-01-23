       public static void Add<T>(string key, T value)
        {
            var current = HttpContext.Current;
            if (current == null) return;
            current.Session.Add(key, value);
        }
        ///Ex.
        public Model User
        {
            set { SessionHelper.Add<Model>("Model ", value); }
        }
