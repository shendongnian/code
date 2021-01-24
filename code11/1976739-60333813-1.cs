    public abstract class Parent
    {
      // The common methods
      public abstract int Id { get; }
    }
    
    public abstract class Parent<TChild> : Parent, IEnumerable<TChild>
    {
      // The methods that are TChild-specific - if you don't need any of those, just drop
      // this class, the non-generic one will work fine
      private List<TChild> children;
      public void Add(TChild child) => ...
      public TChild this[int index] => ...
    }
    
    public class Child : Parent<TChild>
    {
      ...
    }
