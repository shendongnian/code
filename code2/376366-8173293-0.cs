    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    
    ...
    
    // GetManagedSize() returns the size of a structure whose type
    // is 'type', as stored in managed memory. For any referenec type
    // this will simply return the size of a pointer (4 or 8).
    public static int GetManagedSize(Type type)
    {
    	// all this just to invoke one opcode with no arguments!
    	var method = new DynamicMethod("GetManagedSizeImpl", typeof(uint), new Type[0], typeof(TypeExtensions), false);
    
    	ILGenerator gen = method.GetILGenerator();
    
    	gen.Emit(OpCodes.Sizeof, type);
    	gen.Emit(OpCodes.Ret);
    
    	var func = (Func<uint>)method.CreateDelegate(typeof(Func<uint>));
    	return checked((int)func());
    }
