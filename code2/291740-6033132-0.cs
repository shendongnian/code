    public Type GetSharedBaseType(Type a, Type b)
    {
        Type tempA = a;
        Type tempB = b;
        while (tempA != null)
        {
            while (tempB != null)
            {
                if (tempA == tempB)
                    return tempA;
                tempB = tempB.BaseType;
            }
            tempA = tempA.BaseType;
            tempB = b;
        }
        return null;
    }
