    interface Whatever
    {
        void SomeMethod();
    }
    class A : Whatever { public void Whatever() { } }
    
    class B : Whatever { public void Whatever() { } }
    
    enum WhateverType { TypeA, TypeB }
    
    public void GetWhatever( WhateverType type )
    {
        switch( type )
        {
            case WhateverType.TypeA:
                return new A();
                break;
            case WhateverType.TypeB:
                return new B();
                break;
            default:
                Debug.Assert( false );
        }
    }
