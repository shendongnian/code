    class A : IEnumerable
    {
      private List<B> _bList = new List<B>();
      public override ToString()
      {
        return "A";
      }
      IEnumerator GetEnumerator()
      {
        foreach (var bElement in _bList)
        {
          yield return bElement;
        }
      }
      public void Add(B element){
      {
        _bList.Add(element);
      }
    }
    
    class C
    {
      List<A> list;
    }
