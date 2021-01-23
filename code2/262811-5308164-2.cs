    #if IA32
    public struct Sys
    {
       public readonly int Int { get; set; }
    }
    #elif INTEL64
    public struct Sys
    {
       public readonly long Int { get; set; }
    }
    #endif
