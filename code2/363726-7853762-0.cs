    sealed class MyRef<T>
    {
      public T Value { get; set; }
    }
    public class End 
    {
      public MyRef<string> parameter;
      public End(MyRef<string> parameter) 
      {
        this.parameter = parameter;
        this.Init();
        Console.WriteLine("Inside: {0}", parameter.Value);
      }
      public void Init() 
      {
        this.parameter.Value = "success";
      }
    }
    class MainClass 
    {
      public static void Main() 
      {
        MyRef<string> s = new Ref<string>();
        s.Value = "failed";
        End e = new End(s);
        Console.WriteLine("After: {0}", s.Value);
      }
    }
