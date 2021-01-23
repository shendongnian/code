    class C { 
            public virtual string X
            {
                get
                {
                    return ViewState["X"];
                }
                set
                {
                    ViewState["X"] = value;
                }
            }     
            public SetX()
            {
                X=2;
            }
    }
