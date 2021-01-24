    public interface IHaveNumber //or whatever you want to call it
    {
        int i { get; set; } // I would propose a better name for this...
    }
    public int Foo(IHaveNumber input)
    {
        //whatever ...
    }
    public class A : IHaveNumber
    {
        public int i { get; set; }
    }
