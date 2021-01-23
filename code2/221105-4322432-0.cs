    interface IDoSomething
    {
      void DoSomething();
    }
    struct MyStruct : IDoSomething
    {
      public MyStruct(int age)
      {
        this.Age = age;
      }
      public int Age;
      
      pubblic void DoSomething()
      {
        Age++;
      }
    }
    public void DoSomething(IDoSomething something)
    {
      something.DoSomething();
    } 
