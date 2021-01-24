    [CoClass(typeof(SugarGlider))] 
    [ComImport] // pretend as a COM class
    [Guid("000208D5-0000-0000-C000-000000000046")] // put it randomly just to fool the ComImport
    public interface Squirrel
    {
         string Foo();
    }
    [ClassInterface(ClassInterfaceType.None)]
    public class SugarGlider : Squirrel
    {
        public string Foo(){ return "Bar"; }
    }
