    // Assembly 2
    public class C 
    {
        private I _someInternalUseOfI = ...;
        ...
    }
    
    // Assembly 3 - Since in this case, `I` is only used privately in assembly 2,
    // only assembly 2 needs the reference to `I` in assembly 1.
    public static C getC (int id)
    {
       ...
    }
