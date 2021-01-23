    public class MyError : Exception
    {
       public MyError() : base(string.Empty) {}
       public MyError(Exception e) : base(e.Message) {}
       public int MyCustomValue { get; set; }
    }
