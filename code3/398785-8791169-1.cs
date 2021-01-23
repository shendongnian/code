    public abstract class StringField<T> : Field
    {
        public static void Set(DynamicObject obj, string value)
        {
            obj[typeof(T)] = someValue;
        }
    }
    public class UserNameField : StringField<UserNameField> { }
    // To set fields
    UsernameField.Set(obj, someValue);
