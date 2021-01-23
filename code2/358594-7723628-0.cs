    public abstract class FirstBase
    {
       protected internal abstract void Forbidden();
    }
    
    public interface ISecond
    {
      void Test(FirstBase first);
    }
    
    internal class Second : ISecond 
    {
      void Test(FirstBase first)
      {
        first.Forbidden();
      }
    }
