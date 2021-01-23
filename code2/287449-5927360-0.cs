    public interface IWellKnown
    {
       int PropertyA { get; }
       int PropertyB { get; }
    }
    public abstract class WellKnownBase<T> : IWellKnown
    {
       IWellKnown.PropertyA { get { return Convert(this.PropertyA); } }
       IWellKnown.PropertyB { get { return Convert(this.PropertyB); } }
       public T PropertyA { get; }
       public T PropertyA { get; }
       protected virtual int Convert(T input) { return (int)input; }
    }
