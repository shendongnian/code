    void Main() {
        var myFoo = callOnlyOnce(foo);
        myFoo();
        myFoo();
        myFoo();
       var myBar = callOnlyOnce(bar);
       myBar();
       myBar();
       myBar();
    }
    void foo(){
      Console.Write("hello");
    }
    void bar() { Console.Write("world"); }
    
    Action callOnlyOnce(Action action){
        var context = new ContextCallOnlyOnce();
        Action ret = ()=>{
            if(false == context.AlreadyCalled){
                action();
                context.AlreadyCalled = true;
            }
        };
    
        return ret;
    }
    class ContextCallOnlyOnce{
        public bool AlreadyCalled;
    } 
