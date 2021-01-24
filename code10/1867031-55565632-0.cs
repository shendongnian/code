    public class Foo
    {
        private Foo(){}
        private Foo(bool dummy){}
    
        public static FromNormal() { }
    
    #if DEBUG
        public static FromDummy(bool dummy) { }
    #endif
    }
