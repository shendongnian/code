        // not sure how to name 'obj' and 'x' without more context
        private static object GetValue(PropertyInfo obj, PropertyInfo x)
        {
            if (x.GetValue(obj, null) == null) return string.Empty;
            if (x.PropertyType.BaseType == typeof (Enum))
                return Convert.ToInt32(x.GetValue(obj, null));
            
            return x.GetValue(obj, null);
        }
        private static int GetOrder(PropertyInfo x)
        {
            return ((ReportAttribute) Attribute.GetCustomAttribute(x, typeof(ReportAttribute), false)).Order;
        }
