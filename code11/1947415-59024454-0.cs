ICollection collection = (prop.GetValue(obj, null) as ICollection);
if (collection != null)
{
    object[] array = new object[collection.Count];
    collection.CopyTo(array, 0);
    //if you need a list just create a new one and pass in the array: new List<object>(array);
}
As a side note, wouldn't your: 
if (prop.PropertyType.Namespace == "Entities")
{
    object obL = prop.GetValue(obj, null);
    SaveObj(obj);
}
just cause a infinite loop, which will lead to a `StackOverflow`/`OutOfMemory` exception, might want to change it to `SaveObj(obL);` if that was the intended behavior.
