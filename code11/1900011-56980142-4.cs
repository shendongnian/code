    public class Group1
    {
       public string Source { get; }
       public Group1(string source) => Source = source;
       public string MethodOne() => Source + "My Method One";
       public string MethodTwo() => Source + "My Method Two";
    }
    
    public class Group2
    {
       public string Source { get; }
       public Group2(string source) => Source = source;
       public string MethodOne() => Source + "My Method One";
       public string MethodTwo() => Source + "My Method Two";
    }
