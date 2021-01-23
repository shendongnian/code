    public Type[] BaseGenericTypes<T>(T instance)
        {
            Type instanceType = instance.GetType();
    
            Type objectType = new object().GetType();
    
            while (instanceType.BaseType != objectType)
            {
                instanceType = instanceType.BaseType;
            }
            return instanceType.GetGenericArguments();
        }
