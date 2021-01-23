        Rect visualContentBounds = (Rect)GetPrivatePropertyValue(myShape, "VisualContentBounds");
        /*...*/
        private static object GetPrivatePropertyValue(object obj, string propName)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            
            Type t = obj.GetType();
            PropertyInfo pi = t.GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            
            if (pi == null)
                throw new ArgumentOutOfRangeException("propName", string.Format("Field {0} was not found in Type {1}", propName, obj.GetType().FullName));
            
            return pi.GetValue(obj, null);
        }
