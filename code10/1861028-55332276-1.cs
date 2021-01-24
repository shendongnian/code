    public object ChooseProperty((FooItem item,string property)pair){
        PropertyInfo prop=pair.item.GetType().GetProperty(pair.property);
        object value=prop.GetValue(item);
        return value;
    }
