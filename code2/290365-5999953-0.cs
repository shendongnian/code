    public interface IMyObj
    {
        void myMethod();
    }
    public abstract class MyObjBase
    {
        public string myProperty { get; set; }
    }
    public class myObj : MyObjBase,IMyObj
    {
        public void myMethod()
        { }
    }
    public void SomeMethod(myObj myobj)
    {
        myobj.myProperty = "value";         
    }
