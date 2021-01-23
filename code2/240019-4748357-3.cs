    public interface IApple
    {
        int I {get;set;}
        int J {get;set;}
    }
    public class GrannySmith :IApple
    {
         public int I {get;set;}
         public int J {get;set;}
 
    }
    //then a method
    public void DoSomething(IApple apple)
    {
        int i = apple.I;
        //etc...
    }
    //and an example usage
    IApple apple = new GrannySmith();
    DoSomething(apple);
