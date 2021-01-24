    .class private auto ansi '<Module>'
    {
    } // end of class <Module>
    
    .class public auto ansi beforefieldinit Program
        extends [System.Private.CoreLib]System.Object
    {
        // Fields
        .field private static literal float32 scale = float32(65536)
    
        // Methods
        .method public hidebysig static 
            void Main () cil managed 
        {
            // Method begins at RVA 0x2050
            // Code size 17 (0x11)
            .maxstack 8
    
            IL_0000: ldc.i4 859091763
            IL_0005: call void [System.Console]System.Console::WriteLine(uint32)
            IL_000a: ldc.i4.0
            IL_000b: call void [System.Console]System.Console::WriteLine(uint32)
            IL_0010: ret
        } // end of method Program::Main
    
        .method public hidebysig specialname rtspecialname 
            instance void .ctor () cil managed 
        {
            // Method begins at RVA 0x2062
            // Code size 7 (0x7)
            .maxstack 8
    
            IL_0000: ldarg.0
            IL_0001: call instance void [System.Private.CoreLib]System.Object::.ctor()
            IL_0006: ret
        } // end of method Program::.ctor
    
    } // end of class Program
