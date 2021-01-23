    public abstract class BaseType<T>
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual T Value { get; set; }
    }
    public class IntegerValue : BaseType<int>
    { }
    public class DoubleValue : BaseType<double>
    { }
