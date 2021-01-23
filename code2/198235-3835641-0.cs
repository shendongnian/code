    public class Column<T>
    {
        public static explicit operator T(Column<T> value)
        {
            return value;
        }
        private T value;
    }
