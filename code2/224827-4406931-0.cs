    public void MyMethod(Func<int, bool> predicate)
    {
      if (predicate(5))
      {
        // true
      }
      else
      {
        // false
      }
    }
    // To call MyMethod, pass a delegate instance (here we are using a lambda expression)
    MyMethod(x => { if (x > 5) return true; return false; }); 
