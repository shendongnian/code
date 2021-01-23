    static public class Trim<T>
        where T : class
    {
        static public readonly Action<T> TrimAllStringFields = Trim<T>.CreateTrimAllStringFields();
     
        static private Action<T> CreatTrimAllStringFields()
        {
            var instance = Expression.Parameter(typeof(T));
            return Expression.Lambda<Action<T>>(Expression.Block(instance.Type.GetFields(BindingsFlags.Instance| BindingFlags.NonPublic | BindingFlags.Public).Select(field => Expression.Assign(Expression.Field(instance, field)) as Expression), instance).Compile();
        }
    }
