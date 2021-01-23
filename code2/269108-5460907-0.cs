    public void MyFunc<T>(T myParam)
       where T : IEnumerable // or some other interface or base class.
    {
       foreach (var child in myParam) // uses the interface IEnumerable that the generic was constrained to
       {
          // do something
       }
    }
