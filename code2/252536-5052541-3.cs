            //  Microsoft (R) .NET Framework IL Disassembler.  Version 4.0.30319.1
            //  Copyright (c) Microsoft Corporation.  All rights reserved.
            // Metadata version: v4.0.30319
            .assembly extern mscorlib
            {
              .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
              .ver 4:0:0:0
            }
            .assembly del
            {
              .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
              .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                         63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
              .hash algorithm 0x00008004
              .ver 0:0:0:0
            }
            .module del.exe
            // MVID: {87A2A843-A5F2-4D40-A96D-9940579DE26E}
            .imagebase 0x00400000
            .file alignment 0x00000200
            .stackreserve 0x00100000
            .subsystem 0x0003       // WINDOWS_CUI
            .corflags 0x00000001    //  ILONLY
            // Image base: 0x0000000000B60000
            // =============== CLASS MEMBERS DECLARATION ===================
            .class private auto ansi beforefieldinit A
                   extends [mscorlib]System.Object
            {
              .field private int32 _x
              .method public hidebysig specialname rtspecialname 
                      instance void  .ctor(int32 x) cil managed
              {
                // Code size       17 (0x11)
                .maxstack  8
                IL_0000:  ldarg.0
                IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
                IL_0006:  nop
                IL_0007:  nop
                IL_0008:  ldarg.0
                IL_0009:  ldarg.1
                IL_000a:  stfld      int32 A::_x
                IL_000f:  nop
                IL_0010:  ret
              } // end of method A::.ctor
              .method public hidebysig instance void 
                      Print(int32 y) cil managed
              {
                // Code size       16 (0x10)
                .maxstack  8
                IL_0000:  nop
                IL_0001:  ldarg.0
                IL_0002:  ldfld      int32 A::_x
                IL_0007:  ldarg.1
                IL_0008:  add
                IL_0009:  call       void [mscorlib]System.Console::WriteLine(int32)
                IL_000e:  nop
                IL_000f:  ret
              } // end of method A::Print
            } // end of class A
            .class interface private abstract auto ansi IPseudoDelegateVoidInt
            {
              .method public hidebysig newslot abstract virtual 
                      instance void  Call(int32 y) cil managed
              {
              } // end of method IPseudoDelegateVoidInt::Call
            } // end of class IPseudoDelegateVoidInt
            .class private auto ansi beforefieldinit PseudoDelegateAPrint
                   extends [mscorlib]System.Object
                   implements IPseudoDelegateVoidInt
            {
              .field private class A _target
              .method public hidebysig specialname rtspecialname 
                      instance void  .ctor(class A target) cil managed
              {
                // Code size       17 (0x11)
                .maxstack  8
                IL_0000:  ldarg.0
                IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
                IL_0006:  nop
                IL_0007:  nop
                IL_0008:  ldarg.0
                IL_0009:  ldarg.1
                IL_000a:  stfld      class A PseudoDelegateAPrint::_target
                IL_000f:  nop
                IL_0010:  ret
              } // end of method PseudoDelegateAPrint::.ctor
              .method public hidebysig newslot virtual final 
                      instance void  Call(int32 y) cil managed
              {
                // Code size       15 (0xf)
                .maxstack  8
                IL_0000:  nop
                IL_0001:  ldarg.0
                IL_0002:  ldfld      class A PseudoDelegateAPrint::_target
                IL_0007:  ldarg.1
                IL_0008:  callvirt   instance void A::Print(int32)
                IL_000d:  nop
                IL_000e:  ret
              } // end of method PseudoDelegateAPrint::Call
            } // end of class PseudoDelegateAPrint
            .class private auto ansi beforefieldinit Program
                   extends [mscorlib]System.Object
            {
              .class auto ansi sealed nested private RealVoidIntDelegate
                     extends [mscorlib]System.MulticastDelegate
              {
                .method public hidebysig specialname rtspecialname 
                        instance void  .ctor(object 'object',
                                             native int 'method') runtime managed
                {
                } // end of method RealVoidIntDelegate::.ctor
                .method public hidebysig newslot virtual 
                        instance void  Invoke(int32 x) runtime managed
                {
                } // end of method RealVoidIntDelegate::Invoke
                .method public hidebysig newslot virtual 
                        instance class [mscorlib]System.IAsyncResult 
                        BeginInvoke(int32 x,
                                    class [mscorlib]System.AsyncCallback callback,
                                    object 'object') runtime managed
                {
                } // end of method RealVoidIntDelegate::BeginInvoke
                .method public hidebysig newslot virtual 
                        instance void  EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
                {
                } // end of method RealVoidIntDelegate::EndInvoke
              } // end of class RealVoidIntDelegate
              .method private hidebysig static void  Main() cil managed
              {
                .entrypoint
                // Code size       45 (0x2d)
                .maxstack  3
                .locals init (class A V_0,
                         class IPseudoDelegateVoidInt V_1,
                         class Program/RealVoidIntDelegate V_2)
                IL_0000:  nop
                IL_0001:  ldc.i4.5
                IL_0002:  newobj     instance void A::.ctor(int32)
                IL_0007:  stloc.0
                IL_0008:  ldloc.0
                IL_0009:  newobj     instance void PseudoDelegateAPrint::.ctor(class A)
                IL_000e:  stloc.1
                IL_000f:  ldloc.0
                IL_0010:  ldftn      instance void A::Print(int32)
                IL_0016:  newobj     instance void Program/RealVoidIntDelegate::.ctor(object,
                                                                                      native int)
                IL_001b:  stloc.2
                IL_001c:  ldloc.1
                IL_001d:  ldc.i4.2
                IL_001e:  callvirt   instance void IPseudoDelegateVoidInt::Call(int32)
                IL_0023:  nop
                IL_0024:  ldloc.2
                IL_0025:  ldc.i4.2
                IL_0026:  callvirt   instance void Program/RealVoidIntDelegate::Invoke(int32)
                IL_002b:  nop
                IL_002c:  ret
              } // end of method Program::Main
              .method public hidebysig specialname rtspecialname 
                      instance void  .ctor() cil managed
              {
                // Code size       7 (0x7)
                .maxstack  8
                IL_0000:  ldarg.0
                IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
                IL_0006:  ret
              } // end of method Program::.ctor
            } // end of class Program
            // =============================================================
            // *********** DISASSEMBLY COMPLETE ***********************
            // WARNING: Created Win32 resource file C:\Users\logan\del.res
