    public class Foo
    {
        private Foo(string s){
        }
        // Allowed
        public Foo() : this("hello") {
        }
    }
    
    public class Bar : Foo
    {
        // Allowed
        public Bar(string s) : base(){
        }
        // Not allowed
        public Bar(string s) : base(s){
        }
    }
