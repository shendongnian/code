    Type type = myClass.GetType();
    Type listType = typeof(List<>);
    Type[] typeArgs = { type };
    Type genericListType = listType.MakeGenericType(typeArgs);
    object list = Activator.CreateInstance(genericListType, null);
