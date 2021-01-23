        public delegate void Callback<T>();
        public void InitRoute<T>(string pattern, Callback<T> c)
        {
            if(matches)
                c.Invoke();
        }
