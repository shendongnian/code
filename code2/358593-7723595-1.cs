    public interface IFirst
    {
      // whatever ...
    }
    
    internal interface IPrivate : IFirst
    {
        void Forbidden();
    }
    
    public interface ISecond
    {
      void Test(IFirst first);
    }
    
    internal class Second : ISecond 
    {
      void Test(IFirst first)
      {
        var priv = first as IPrivate;
        if (priv != null)
            priv.Forbidden();
      }
    }
