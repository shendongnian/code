    interface IHome<out T> {
      string GetClassType { get; }
    }
    public class Home<T> : IHome<T> where T : class
    {
      public string GetClassType
      {
          get { return typeof(T).Name; }
      }
    }
