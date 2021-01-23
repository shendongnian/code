    private Action<TListPropertyContainer, TDataValue> 
        CreateListPropertySetter<TListPropertyContainer, TDataValue>
        (string listName, object target)
    {
        var listProperty = typeof(TListPropertyContainer).GetProperty(listName);
        object list = listProperty.GetValue(target, null);
        var method = typeof(Extensions).GetMethod("AddCSV");
        return (Action<TListPropertyContainer, TDataValue>)Delegate.CreateDelegate(
            typeof(Action<TListPropertyContainer, TDataValue>), list, method);
    }
