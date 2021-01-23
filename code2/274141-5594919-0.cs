       .locals init (string  V_0, class [mscorlib]System.Collections.Generic.IEnumerable`1<char>  V_1)
       IL_0000:  ldstr "Sean\\John\\\\Rob\\fred"
       IL_0005:  stloc.0
       IL_0006:  ldloc.0
       IL_0007:  call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> class [System.Core]System.Linq.Enumerable::Reverse<char> (class [mscorlib]System...
       IL_000c:  ldsfld class [mscorlib]System.Func`2<char,bool> qqq.MainClass::'<>f__am$cache0'
       IL_0011:  brtrue.s IL_0024
       IL_0013:  ldnull
       IL_0014:  ldftn bool class qqq.MainClass::'<Main>m__0'(char)
       IL_001a:  newobj instance void class [mscorlib]System.Func`2<char, bool>::'.ctor'(object, native int)
       IL_001f:  stsfld class [mscorlib]System.Func`2<char,bool> qqq.MainClass::'<>f__am$cache0'
       IL_0024:  ldsfld class [mscorlib]System.Func`2<char,bool> qqq.MainClass::'<>f__am$cache0'
       IL_0029:  call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> class [System.Core]System.Linq.Enumerable::TakeWhile<char> (class [mscorlib]Syst...
       IL_002e:  call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> class [System.Core]System.Linq.Enumerable::Reverse<char> (class [mscorlib]System...
       IL_0033:  stloc.1
       IL_0034:  ldloc.1
       IL_0035:  call !!0[] class [System.Core]System.Linq.Enumerable::ToArray<char> (class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
       IL_003a:  newobj instance void string::'.ctor'(char[])
       IL_003f:  stloc.0
       //
       //
       // With the Lambda expression (ch => '\\' != ch) compiled to:
       // 
       // method line 3
       .method private static hidebysig
              default bool '<Main>m__0' (char ch)  cil managed
       {
           .custom instance void class [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::'.ctor'() =  (01 00 00 00 ) // ....
   
           // Method begins at RVA 0x214c
           // Code size 9 (0x9)
           .maxstack 8
           IL_0000:  ldc.i4.s 0x5c  // '\\' character
           IL_0002:  ldarg.0
           IL_0003:  ceq
           IL_0005:  ldc.i4.0
           IL_0006:  ceq
           IL_0008:  ret
       } // end of method MainClass::<Main>m__0
