    public interface IApple
    {
        public int I {get;set;}
        public int J {get;set;}
    }
    public class GrannySmith :IApple
    {
         public int I {get;set;}
         public int J {get;set;}
 
    }
    //then a method
    public void DoDomething(IApple apple)
    {
        int i = apple.I;
        //etc...
    }
