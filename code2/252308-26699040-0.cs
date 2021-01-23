        public static T ForceType<T>(this object o)
        {
            T res;
            res = Activator.CreateInstance<T>();
            Type x = o.GetType();
            Type y = res.GetType();
            foreach (var destinationProp in y.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                var sourceProp = x.GetProperty(destinationProp.Name);
                if (sourceProp != null)
                {
                    destinationProp.SetValue(res, sourceProp.GetValue(o));
                }
            }
            return res;
        }
