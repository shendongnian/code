    public interface IMyInterface
    {
       void SomeMethod(DataUnit x);
    }
    
    public class RealThing : IMyInterface
    {
       public void SomeMethod(DataUnit x)
       {
           SomeServiceClient svc = new SomeServiceClient();
           svc.SomeMethod(x);
       }
    }
    
    public class TestThing : IMyInterface
    {
       public void SomeMethod(DataUnit x)
       {
           // do your test here
       }
    }
