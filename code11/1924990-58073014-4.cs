class IndexerClass
{
    public object this[int index]
    {
        get
        {
            return (index + 1);
        }
    }
    internal string this[bool index]
    {
        get
        {
            return index.ToString();
        }  
    }
    private int this[IList<int> list, bool defValueIfNone]
    {
        get
        {
            if ((list == null) || (list.Count == 0))
            {
                if (defValueIfNone)
                {
                    return 0;
                }
                throw new ArgumentException("Invalid list");
            }
            return list[0];
        }
    }     
}
The name which is used for indexers is `Item`, note that if a class has a indexer(s) it can't have a property named `Item` as it would conflict with them.
To find the indexer which accepts the `int index`, the only foolproof way of doing so is like this:
var instance = new IndexerClass();
var type = typeof(IndexerClass); //sins you get a value just do: value.GetType();
var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
if (props.Length > 0)
{
    foreach (var prop in props)
    {
        if (prop.Name == "Item")
        {
            var i_param = prop.GetIndexParameters();
            if (i_param.Length == 1)
            {
                if (i_param[0].ParameterType == typeof(int)) //you can also add `||` and check if the ParameterType is equal to typeof sbyte, byte, short, ushort, uint, long, ulong, float or double.
                {
                    return prop.GetValue(instance, new object[] { 0 });
                }
            }
        }
    }
}
return null;
