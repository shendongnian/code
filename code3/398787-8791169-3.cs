    public abstract class GenericField<T, U> : Field
    {
        public void Set(DynamicObject obj, T value)
        {
            obj[typeof(U)] = value;
        }
    }
    public class UsernameField : GenericField<string, UsernameField> { }
