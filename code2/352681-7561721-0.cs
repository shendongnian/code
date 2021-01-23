    public abstract class EnumBase<T> where T : EnumBase<T>
    {
        protected static T ValueOfImpl(int value)
        {
            ...
        }
    }
    public class Color : EnumBase<Color>
    {
        // static fields
        // Force initialization on any access, not just on field access
        static Color() {}
        // Each derived class would have this.
        public static Color ValueOf(int value)
        {
            return ValueOfImpl(value);
        }
    }
