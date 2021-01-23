     class A 
     {
         public virtual void Foo() { }
     }
    
     class B : A 
     {
         public new void Foo() { }
         public new void Bar() { }
         public void Baz() { }   //it's also new
     }
