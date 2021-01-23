    public interface IBase<out TElement>
    {
        TElement Element { get; }
    }
    class Base<TElement> : IBase<TElement>
    {
        public TElement Element { get; set; }
    }
    class Concrete : Base<string>  {  }
    
