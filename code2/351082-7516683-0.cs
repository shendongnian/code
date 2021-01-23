    namesapce A
    {
        namespace B
        {
            class Foo { }
        }
    
        namespace C
        {
            class Bar { private B.Foo f; }  // B is a 'relative' ns
        }
    }
