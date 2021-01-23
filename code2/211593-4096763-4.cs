    public abstract class Helper<T>
    {
        public static string DoSomething<TEnum>(TEnum value) where TEnum: struct, T
        {
            if (!Enum.IsDefined(typeof(TEnum), value))
            {
                value = default(TEnum);
            }
            // ... do some other stuff
            // just to get code to compile
            return value.ToString();
        }
    }
    public class EnumHelper : Helper<Enum> { }
