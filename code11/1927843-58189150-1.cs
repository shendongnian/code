C#
public static barChecker<T> Generator()
{
    var rtn = new barChecker<T>();
    foreach (var item in typeof(T).GetProperties())
    {
        if (item.PropertyType.InheritsFrom(typeof(foo<>)))
        {
            rtn.fooprops.Add(item);
        }
    }
    return rtn;
}
