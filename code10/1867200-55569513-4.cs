    public class SomeClass
    {
       public int First { get; set; }
       public int Second { get; set; }
       public SomeClass(int first, int second)
       {
          First = first;
          Second = second;
       }
    }
 
    ...
   
    public SomeClass ViaSomeClass()
    {
       return new SomeClass(1, 2);
    }
    
    ...
 
    var someClass = ViaSomeClass();
    Console.WriteLine($"{someClass.First}, {someClass.Second}");
