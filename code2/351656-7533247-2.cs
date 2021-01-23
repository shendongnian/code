     .method private hidebysig 
    	instance void UseWhereAndAny () cil managed 
    {
    	// Method begins at RVA 0x20d8
    	// Code size 50 (0x32)
    	.maxstack 4
    	.locals init (
    		[0] bool moreThan2
    	)
    
    	IL_0000: nop
    	IL_0001: ldarg.0
    	IL_0002: ldfld class [mscorlib]System.Collections.Generic.List`1<string> AnyWhere.Program::data
    	IL_0007: ldsfld class [mscorlib]System.Func`2<string, bool> AnyWhere.Program::'CS$<>9__CachedAnonymousMethodDelegate2'
    	IL_000c: brtrue.s IL_0021
    
    	IL_000e: ldnull
    	IL_000f: ldftn bool AnyWhere.Program::'<UseWhereAndAny>b__1'(string)
    	IL_0015: newobj instance void class [mscorlib]System.Func`2<string, bool>::.ctor(object, native int)
    	IL_001a: stsfld class [mscorlib]System.Func`2<string, bool> AnyWhere.Program::'CS$<>9__CachedAnonymousMethodDelegate2'
    	IL_001f: br.s IL_0021
    
    	IL_0021: ldsfld class [mscorlib]System.Func`2<string, bool> AnyWhere.Program::'CS$<>9__CachedAnonymousMethodDelegate2'
    	IL_0026: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Where<string>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [mscorlib]System.Func`2<!!0, bool>)
    	IL_002b: call bool [System.Core]System.Linq.Enumerable::Any<string>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    	IL_0030: stloc.0
    	IL_0031: ret
    } // end of method Program::UseWhereAndAny
