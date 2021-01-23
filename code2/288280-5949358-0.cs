    class A
    {
        public virtual int BoardSize { get; set; }
    }
    class B : A
    {
      public override int BoardSize
      {
        get { return 100; }
        set {
          throw new InvalidOperationException("Cannot set BoardSize on class B.");
        }
      }
    }
