       class A
        {
            public virtual string prop { get; set; }
        }
    
        class B : A
        {
            public override string prop
            {
                get
                {
                    return "overridden";
                }
                set
                {
                    base.prop = value;
                }
            }
        }
