foreach (var myProperty in myObject.GetType().GetProperties())
{
    //get generic property (type IList)
    if (myProperty.PropertyType.IsGenericType)
    {
        var listProperty = myProperty.GetValue(myObject) as IEnumerable;
        foreach (var test in listProperty)
        {
            //Do some magic
        }
    }
}
