    public class NullableExtensions 
    {
        public static implicit operator int(int? value)
        {
            return value ?? default(int);
        }
    }
