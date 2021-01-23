	using System;
	using System.Reflection;
	class Program
	{
	    public delegate uint Ret1ArgDelegate(uint arg1);
	    static uint PlaceHolder1(uint arg1) { return 0; }
	    
	    public static byte[] asmBytes = new byte[]
		{        
	0x89,0xD0, // MOV EAX,EDX
	0xD1,0xC8, // ROR EAX,1
	0xC3       // RET
		};
		
	    unsafe static void Main(string[] args)
	    {
		fixed(byte* startAddress = &asmBytes[0]) // Take the address of our x86 code
		{
		    // Get the FieldInfo for "_methodPtr"
		    Type delType = typeof(Delegate);
		    FieldInfo _methodPtr = delType.GetField("_methodPtr", BindingFlags.NonPublic | BindingFlags.Instance);
		    // Set our delegate to our x86 code
		    Ret1ArgDelegate del = new Ret1ArgDelegate(PlaceHolder1);
		    _methodPtr.SetValue(del, (IntPtr)startAddress);
		    // Enjoy
		    uint n = (uint)0xFFFFFFFC;
		    n = del(n);
		    Console.WriteLine("{0:x}", n);
		}
	    }
	}
