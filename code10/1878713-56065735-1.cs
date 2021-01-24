    interface IWoof
    {
       void Woof();
       void Woof(System.Action callback)
    }
    public void Foo(IWoof dog)
    {
      dog.Woof();
      dog.Woof(() => SomeOtherFunction());
    }
    class MyWoof : IWoof
    {
      public void Woof(){
       Console.WriteLine("woof");
      }
      public void Woof(System.Action callback){
        Console.WriteLine("woof with callback");
        callback();
      }
    }
    Foo(new MyWoof());
     
