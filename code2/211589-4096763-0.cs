    public abstract class Helper<T>
    {
        public static string DoSomething<TEnum>(TEnumvalue) where TEnum: struct, T
        {
            if (!Enum.IsDefined(typeof(TEnum), value))
            {
                value = default(TEnum);
            }
            // ... do some other stuff
        }
    }
    public class EnumHelper : Helper<Enum> { }
