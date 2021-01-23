    #if IA32
    public struct Sys
    {
       public int Int { get; set; }
    }
    #elif INTEL64
    public struct Sys
    {
       public long Int { get; set; }
    }
    #endif
