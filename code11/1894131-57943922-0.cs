            public T InstantiatePage<T>() where T : class
        {
            // COUNTRY code as defined in
            // https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2#Officially_assigned_code_elements
            var className = string.Format("{0}_{1}", typeof(T).FullName, getCulture()); 
            // T will be base class if no derived class with COUNTRY code suffix is found 
            var classType = Type.GetType(className) ?? typeof(T);
            
            // Instantiate the page
            var instance = Activator.CreateInstance(classType, new object[] { WebDriver });
            return (T)instance;
        }
