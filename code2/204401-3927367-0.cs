    if (entityList.GetType().IsGenericType && 
        entityList.GetType().GetGenericTypeDefinition() == typeof(EntityList<>) && 
        entityList.GetType().GetGenericTypeDefinition().GetGenericArguments()[0] == type) 
    {
        ...
    }
