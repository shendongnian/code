    class MyClass<T> where T : SomeClass
    {
       void SomeMethod(T t)
       {
          ISomeInterface obj1 = (ISomeInterface)t;
          SomeClass      obj2 = (SomeClass)t;     
       }
    }
