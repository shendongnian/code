    public interface IFoo
    {
        public void Bar();
        public bool Baz();
    }
    public abstract class BaseFoo : IFoo
    {
        //fields/properties used in all classes
        public void Bar()
        { //Implementation }
        public bool Baz()
        { //Implementation }
    }
    public class DerivedFoo : BaseFoo, IFoo {...}
