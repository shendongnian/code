       public T CreateInstance()
        {
            string fullClassName = typeof(T).ToString();
            string[] splitClassName = fullClassName.Split('.');
            _className = splitClassName[2];
            _assemblyName = splitClassName[0] + "." + _client + "." + splitClassName[1];
            _fullyQualifiedClassName = _assemblyName + "." + _className;
            T obj;
            var assemblies = HttpContext.Current.Session["ASSEMBLIES"] as Dictionary<string, T>;
            if (assemblies == null)
            {
                assemblies = new Dictionary<string, T>();
                assemblies.Add(_fullyQualifiedClassName, null);
                HttpContext.Current.Session.Add("ASSEMBLIES", assemblies);
            }
            obj = assemblies[_fullyQualifiedClassName] as T;
            if (obj == null)
            {
                obj = (T)Activator.CreateInstance(Type.GetType(_fullyQualifiedClassName + "," + _assemblyName));
                assemblies[_fullyQualifiedClassName] = obj;
            }
            
            return obj;
        }
