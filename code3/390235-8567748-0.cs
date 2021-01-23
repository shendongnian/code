    class B<T>
    {
      public virtual void M(T t) {}
      public virtual void M(int x) {}
    }
    class D : B<int>
    {
      public override void M(int x) {}
    }
