    interface ISomeInterface
    {}
    class SomeClass
    {}
    sealed class SealedClass
    {
    }
    class OtherClass
    {
    }
    class DerivedClass : SomeClass, ISomeInterface
    {
    }
    class MyClass
    {
      void OtherMethod(SomeClass s)
      {
        ISomeInterface t = (ISomeInterface)s; // Compiles!
      }
      void OtherMethod2(SealedClass sc)
      {
        ISomeInterface t = (ISomeInterface)sc; // Does not compile!
      }
      void OtherMethod3(SomeClass c)
      {
        OtherClass oc = (OtherClass)c; // Does not compile because compiler knows 
      }                                // that SomeClass does not inherit from OtherClass!
      void OtherMethod4()
      {
        OtherMethod(new DerivedClass()); // In this case the cast to ISomeInterface inside
      }                                  // the OtherMethod is valid!
    }
