    public MyClass<TClass> where TClass : class
    {
         public void MyFunc<T>() where T : TClass
         {
             // who cares ?
         }
    }
