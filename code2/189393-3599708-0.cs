    public class MySpecialCollection<T> where T : ISomething<T> {
      ...
    }
    
    public interface ISomething<T> {
      T NextElement { get; }
      T PreviousElement { get; }
    }
    public class XSomething : ISomething<XSomething> {
      ...
    }
