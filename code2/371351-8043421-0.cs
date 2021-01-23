    interface I
    {
      int X { get; }
    }
    
    class A : I
    {
      int X { get; set; }
    }
    
    class B<T> : I
    {
       void F(T t) {}
       int X { get; set; }
    }
