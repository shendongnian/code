    // Assembly 2
    public class C : I
    {
        ...
    }
    
    // Assembly 3 - needs definition of `I` from assembly 1 because part of `C`
    // public definition.
    public static C getC (int id)
    {
       ...
    }
