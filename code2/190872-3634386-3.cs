    using System.Reflection;
    public static class WithExtension
    {
        public static T With<T>(this T target, object values)
        {
            Type targetType = typeof(T);
    
            foreach (PropertyInfo prop in values.GetType().GetProperties())
            {
                PropertyInfo targetProp = targetType.GetProperty(prop.Name);
                if (targetProp != null && targetProp.PropertyType==prop.PropertyType)
                {
                    targetProp.SetValue(target, prop.GetValue(values, null), null );
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            return target;
        }
    }
