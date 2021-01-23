        .method private hidebysig 
    	instance void UseAny () cil managed 
    {
    	// Method begins at RVA 0x2134
    	// Code size 45 (0x2d)
    	.maxstack 4
    	.locals init (
    		[0] bool moreThan2
    	)
    
    	IL_0000: nop
    	IL_0001: ldarg.0
    	IL_0002: ldfld class [mscorlib]System.Collections.Generic.List`1<string> AnyWhere.Program::data
    	IL_0007: ldsfld class [mscorlib]System.Func`2<string, bool> AnyWhere.Program::'CS$<>9__CachedAnonymousMethodDelegate4'
    	IL_000c: brtrue.s IL_0021
    
    	IL_000e: ldnull
    	IL_000f: ldftn bool AnyWhere.Program::'<UseAny>b__3'(string)
    	IL_0015: newobj instance void class [mscorlib]System.Func`2<string, bool>::.ctor(object, native int)
    	IL_001a: stsfld class [mscorlib]System.Func`2<string, bool> AnyWhere.Program::'CS$<>9__CachedAnonymousMethodDelegate4'
    	IL_001f: br.s IL_0021
    
    	IL_0021: ldsfld class [mscorlib]System.Func`2<string, bool> AnyWhere.Program::'CS$<>9__CachedAnonymousMethodDelegate4'
    	IL_0026: call bool [System.Core]System.Linq.Enumerable::Any<string>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [mscorlib]System.Func`2<!!0, bool>)
    	IL_002b: stloc.0
    	IL_002c: ret
    } // end of method Program::UseAny
