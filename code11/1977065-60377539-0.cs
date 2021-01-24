csharp
public class BaseClassMap<TClass> : ClassMap<TClass> where TClass : class
{
    public BaseClassMap(List<string> columns)
    {
        var index = 0;
        PropertyInfo[] props = typeof(TClass).GetProperties();
        foreach (PropertyInfo prop in props)
        {
            index = columns.IndexOf(prop.Name);
            if (index != -1)
            {
                var columnAttribute = prop.GetCustomAttributes(false).FirstOrDefault(a => a.GetType() == typeof(ColumnAttribute)) as ColumnAttribute;
                Map(typeof(TClass), prop).Name(columnAttribute != null ? columnAttribute.Name : prop.Name);
            }
        }
    }
}
