    public class Deletable<T>
    {
        public Deletable(T value)
        {
            Value = value;
        }
        public T Value { get; }
        public bool Delete { get; private set; }
        public void MarkForDeletion() => Delete = true;
    }
