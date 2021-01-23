    public abstract class GenericField<T, U> : Field
    {
        public static void Set(DynamicObject obj, T value)
        {
            obj[typeof(U)] = value;
        }
    }
    public class UsernameField : GenericField<string, UsernameField> { }
