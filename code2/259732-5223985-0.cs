        public static object ConvertTo(Type type, string inject)
        {
            if (inject == null)
            {
                return type.IsValueType ? Activator.CreateInstance(type) : null;
            }
            if (type.IsInstanceOfType(inject))
            {
                return inject;
            }
            else if (type == typeof(int))
            {
                int temp;
                if (int.TryParse(inject, out temp))
                    return temp;
                return null;
            }
            else if (typeof(IConvertible).IsAssignableFrom(type))
            {
                return Convert.ChangeType(inject, type);
            }
            //Maybe we have a constructor that accept the type?
            ConstructorInfo ctor = type.GetConstructor(new Type[] { inject.GetType() });
            if (ctor != null)
            {
                return Activator.CreateInstance(type, inject);
            }
            //Maybe we have a Parse method ??
            MethodInfo parseMethod = type.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public);
            if (parseMethod != null)
            {
                return parseMethod.Invoke(null, new object[] { inject });
            }
            throw new ArgumentException(string.Format(
                "Cannot convert value '{0}' of type '{1}' to request type '{2}'", 
                inject,
                inject.GetType(), 
                type));
        }
