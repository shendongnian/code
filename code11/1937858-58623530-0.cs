    using BaseNamespaceAbcAndXyzSee;
    
    namespace abc
    {
        class A : IA
  
        {
            public void Foo() { }
        }
    }
    
    namespace xyz
    {
        class A : IA
        {
            public void Foo() { }
        }
    }
    
    namespace BaseNamespaceAbcAndXyzSee
    {
        interface IA
        {
            void Foo();
        }
    }
