    var type = typeof(TValue);
    if(type == typeof(int))
    {
        serializedProperty.intValue = value;
    }
    else if(type == typeof(string)
    {
        serializedProperty.stringValue = value;
    }
    ...
    else if(type.IsAssignableFrom(typeof(UnityEngine.Object)))
    {
        serializedProperty.objectReferenceValue = value;
    }
    else
    {
        Debug.LogError("Unassignable type");
    }
