    public interface IHardware1 { }
    public interface IHardware2 { }
    public interface IHardware3 { }
    
    public class Hardware1 : IHardware1 { }
    public class Hardware2 : IHardware2 { }
    public class Hardware3 : IHardware3 { }
    
    
    public class MyClass
    {
        private IHardware1 _a;
        private IHardware2 _b;
        private IHardware3 _c;
    
        public MyClass( IHardware1 hardware1, IHardware2 hardware2, IHardware3 hardware3 )
        {
            _a = hardware1;
            _b = hardware2;
            _c = hardware3;
        }
    
        public int MyMethod( int percent, ref double power )
        {
            ...
                _b.DoThing1( percent );
                _b.DoThing2( true );
                _c.DoSomething1();
            ...
        }
    }
