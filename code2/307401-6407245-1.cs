    class MyClass<T> where T : SomeClass
    {
       void SomeMethod(T t)
       {
          ISomeInterface obj1 = (ISomeInterface)t;//Compiles
          SomeClass      obj2 = (SomeClass)t;     //Does not compile
       }
    }
