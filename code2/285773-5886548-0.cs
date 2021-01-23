    public interface ISomething
    {
        string Name { get; set;}
        void SetName(string newValue);
    }
    // Choose one of these methods to implement; both is overkill
    public class SomethingElse : ISomething
    {
         protected string _internalThing = string.Empty;
         public string Name
         {
             get { return _internalThing; }
             set { throw new InvalidOperationException(); }
         }
         public void SetName(string newValue)
         {
             throw new InvalidOperationException();
         }
    }
