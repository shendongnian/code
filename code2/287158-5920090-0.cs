    public class Base
    {
    }
    
    public class Sub : Base
    {
    }
    
    
    Base baseObj = new Base(); //this is just fine
    Base subAsBase = new Sub(); //this is just fine, a Sub is a type of Base
    
    Sub subAsBase = new Base(); //this will spit a compile error. A Base is NOT a type of Sub, it is the other way around.
