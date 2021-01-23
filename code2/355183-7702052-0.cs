     class MyType : TypeDelegator
        {
           public MyType(Type parent)
              : base(parent)
           {
           }
    
            public override Type UnderlyingSystemType
            {
                get
                {
                    return this;
                }
            }
        }
