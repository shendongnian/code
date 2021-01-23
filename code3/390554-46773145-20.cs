    .method public hidebysig specialname rtspecialname instance void .ctor () cil managed 
    {
        IL_0000: ldarg.0
        IL_0001: call instance void Shadowing_CS.BaseClass::.ctor()
        IL_0006: ret
    }
    
    .method public hidebysig instance string SomeMethod (
            string s
        ) cil managed 
    {
        IL_0000: ldstr "Derived from string"
        IL_0005: ret
    }
