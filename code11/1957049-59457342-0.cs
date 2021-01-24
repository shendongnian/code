        public static void resetControl<T>(this T c, string key = "") where T : Control // Using generic approach for the convenience of being able to use the Type T
        {
            Form f = c.FindForm();
            ComponentResourceManager resources = new ComponentResourceManager(f.GetType()); // Manage the resources from our Form class
            if (key == "")
            {
                resources.ApplyResources(c, c.Name); // Simply natively apply all resources
            }
            else // If we want to reset only one specific property...
            {
                // rather than trying to get to the data serialized away somewhere, I'm using this work-around
                T r = (T)Activator.CreateInstance(c.GetType()); // create a new instance of the Control in question
                resources.ApplyResources(r, c.Name);
                setAttr(c, key, r.getAttr(key)); // setAttr and getAttr are helper extensions I always have on hand as well
            }
        }
        public static void setAttr(this object o, string key, object val)
        {
            foreach (PropertyInfo prop in o.GetType().GetProperties())
            {
                string nam = prop.Name;
                if (nam == key)
                {
                    prop.SetValue(o, val);
                    return;
                }
            }
        }
        public static dynamic getAttr(this object o, string key)
        {
            Type myType = o.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name == key)
                {
                    return prop.GetValue(o, null).ChangeType(prop.PropertyType);
                }
            }
            return null;
        }
