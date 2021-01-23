        public T CommonClone<T>(T Source)
        {
            T ret = System.Activator.CreateInstance<T>();
            Type typeDescr = typeof(T);
            if (typeDescr.IsClass != true)
            {
                ret = Source;
                return ret;
            }
            System.Reflection.FieldInfo[] fi = typeDescr.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public); 
            
            for (int i = 0; i < fi.Length; i++)
            {
                fi[i].SetValue(ret, fi[i].GetValue(Source));
            }
            return ret;
        }
