    class A : IEnumerable
    {
      private List<B> _bList = new List<B>();
      public override ToString()
      {
        return "A";
      }
      IEnumerator GetEnumerator()
      {
        return _bList.GetEnumerator();
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
