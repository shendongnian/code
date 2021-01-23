      public class BaseClass
    {
        float _foo;
        public BaseClass(float foo){_foo = foo;}
        public BaseClass SplitObject()
        {
            Type t = GetType();
            _foo = _foo / 2f;
            //Find the constructor that accepts float type and invoke it:
            System.Reflection.ConstructorInfo ci = t.GetConstructor(new Type[]{typeof(float)});
            object o=ci.Invoke(new object[]{_foo});
            return (BaseClass)o; 
        }
    }
    public class DerivedClass : BaseClass
    {
        public DerivedClass(float foo) : base(foo) { }
    }
    class Program
    {
        static void Main()
        {
            BaseClass foo = new DerivedClass(1f);
           //Cast the BaseClass to DerivedClass:
            DerivedClass bar = (DerivedClass)foo.SplitObject(); 
        }
    }
