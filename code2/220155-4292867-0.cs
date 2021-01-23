    public interface IFooBar
    {
        String GetData();
    }
    
    public class Foo : IFooBar
    {
        public String GetData() { return "Foo"; }
    }
    
    public class Bar : IFooBar
    {
        public String GetData() { return "Bar"; }
    }
    
    public class DataManager
    {
        public static IFooBar GetFooBar()
        {
            IFooBar foobar = ...
            return foobar;
         }
    }
    
    public class MainAppClass
    {
         public void SomeMethod()
         {
             //You don't care what type of class you get here
             //you only care that the object you get back let's you
             //call GetData.
             IFooBar foobar = DataManager.GetFooBar();
             String data = foobar.GetData();
             //etc
         }
    }
