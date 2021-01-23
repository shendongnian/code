    Interface IDecorator{
        public void foo();
    }
    public class OuterDecorator:IDecorator{
        private IDecorator _inner;
        public OuterDecorator(IDecorator inner){
            this.__inner = inner;
        }
        public void foo(){
            this._inner.foo();
            Console.Writeline("Hello from outer");
        }
    }
    
    public class InnerDecorator:IDecorator{
        public void foo(){
            Console.Writeline("Hello from inner");
        }
    }
