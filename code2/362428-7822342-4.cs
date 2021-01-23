        public class Holder<T>
        {
            public Holder(T value)
            {
                Value = value;
            }
            public static implicit operator T(Holder<T> holder)
            {
                return holder.Value;
            }
            public T Value { get; set; }
        }
