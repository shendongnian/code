    if (entityList.GetType().IsGenericType && 
        entityList.GetType().GetGenericTypeDefinition() == typeof(EntityList<>) && 
        entityList.GetType().GetGenericArguments()[0] == type) 
    {
        ...
    }
