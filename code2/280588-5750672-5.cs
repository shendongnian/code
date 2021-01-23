    static void DoIt(object value)
    {
        Entity e = new Entity();
        e.Value = ((IConvertible) value).ToInt32(null);
    }
    L_0000: nop 
    L_0001: newobj instance void ConsoleApplication2.Entity::.ctor()
    L_0006: stloc.0 
    L_0007: ldloc.0 
    L_0008: ldarg.0 
    L_0009: castclass [mscorlib]System.IConvertible
    L_000e: ldnull 
    L_000f: callvirt instance int32 [mscorlib]System.IConvertible::ToInt32(class [mscorlib]System.IFormatProvider)
    L_0014: callvirt instance void ConsoleApplication2.Entity::set_Value(int32)
    L_0019: nop 
    L_001a: ret 
