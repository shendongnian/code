    class ClassChild : ClassParent, IClassProvider
    {
       public ClassParent IClassProvider.Get()
       {
          return Get();
       }
       public ClassChild Get()
       {
          return this;
       }
    }
