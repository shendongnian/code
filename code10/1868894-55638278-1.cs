    public abstract class ConsoleReadType<T> where T: struct
    {
        public abstract T Read();
        public abstract T Read(T? min, T? max);
    }
