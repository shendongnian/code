    public interface IChangeable
    {
        bool Changed { get; set; }
    }
    public class Changeable<T> : IChangeable
    {
        public bool Changed { get; set; }
        public T Value { get; set; }
    }
    public class MyModel
    {
        [MyRange(1, 10)]
        public Changeable<int> SomeInt { get; set; }
    }
    public class MyRangeAttribute : RangeAttribute
    {
        public MyRangeAttribute(double minimum, double maximum): base(minimum, maximum)
        { }
        public MyRangeAttribute(int minimum, int maximum)
            : base(minimum, maximum)
        { }
        public override bool IsValid(object value)
        {
            var changeable = value as IChangeable;
            if (changeable == null || !changeable.Changed)
            {
                return true;
            }
            dynamic dynValue = value;
            return base.IsValid((object)dynValue.Value);
        }
    }
