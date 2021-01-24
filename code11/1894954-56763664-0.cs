public PropertyTypeEnum GetPropertyType(MyPocoClass myPocoClass)
{
    if (myPocoClass.PropertyOne != null)
    {
        return PropertyTypeEnum.TypeOne;
    }
    else if (...)
    {
        return PropertyTypeEnum.TypeN
    }
    else
    {
        // probably throw a NotImplementedException here depending on your requirements
    }
}
Then in your code to use the object you can use the returned Enum to switch on the logical paths of your code.    
