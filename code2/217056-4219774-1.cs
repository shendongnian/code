    public interface IRandomProvider
    {
        Func<double> NextDouble { get; }
    }
    public class StdRandomProvider : IRandomProvider
    {
        Random r = new Random();
        Func<double> NextDouble
        {
            get { return ()=>r.NextDouble(); }
        }
    }
    public class MyRandomProvider : IRandomProvider
    {
        MyRandom r = new MyRandom();
        Func<double> NextDouble
        {
            get { return ()=>r.MyNextDouble(); }
        }
    }
    public class Foo 
    {
       IRandomProvider r;
       Foo(bool use_new) 
       {
           if(use_new)
              r= new MyRandomProvider();
           else
              r= new StdRandomProvider();            
       }
       void bar() 
       {
           ans = r.NextDouble();
           ...
       }
    }
