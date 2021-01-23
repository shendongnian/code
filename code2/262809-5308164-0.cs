    #if IA32
    public struct Sys
    {
       public int Int { get; set }
    }
    #elseif
    public struct Sys
    {
       public long Int { get; set }
    }
    #endif
