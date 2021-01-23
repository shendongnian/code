    public static T DeepClone<T>(this T original, params Object[] args) 
    {
        T result;
        Type t = original.GetType();
        /* Create new instance, at this point you pass parameters to
         * the constructor if the constructor if there is no default constructor
         * or you change it to Activator.CreateInstance<T>() if there is always
         * a default constructor */
        result = (T)Activator.CreateInstance(t, args);
        // Maybe you need here some more BindingFlags
        foreach (FieldInfo field in t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance))
        {
            /* You can filter the fields here ( look for attributes and avoid
             * unwanted fields or even copy arrays if necessary ) */
            Object fieldValue = field.GetValue(original);
            // Check here if the instance should be cloned
            Type ft = field.FieldType;
            // You can check here for ft.GetCustomAttributes(typeof(SerializableAttribute), false).Length != 0 to make things easier
            if (fieldValue != null && !ft.IsValueType && ft != typeof(String))
            {
                /* Create a copy of the reference, at this point you gonna need a Dictionary
                 * to avoid a endless loop ( instance holds instance2, instance2 holds instance )
                 * This could be a static dictionary ( you'll need 2 methods to get it to work, 
                 * because you need do clear it after each cloning ) 
                 * Also a implementation of a array copy is missing, but this should be easy to to */
                fieldValue = fieldValue.DeepClone();
                // Does not support parameters for subobjects (!!!)
            }
            field.SetValue(result, fieldValue);
        }
        return result;
    }
