     private object _dependency;
     private delegate_type _delegate;
    
     public B(object dependency, delegate_type theDelegate)
     {
          _dependency = dependency;
          _delegate= theDelegate;
     }
    
     public B(object dependency) : this(dependency, delegate(){ Method2(); }) {}
     
     public void Method()
     {
         dependency.DependencyMethod(theDelegate);
     }
