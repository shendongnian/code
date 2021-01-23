    public class MyClass
    {
       private List<string> _inner = new List<string>();
       public IEnumerable<string> Items
       {
          get { return _inner.GetEnumerator(); }
       }
       public void AddItem(string item);
       {
          _inner.Add(item);
       }
    }
