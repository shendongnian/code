    #pragma once
    using namespace System;
    namespace NativeLib {
	    public ref class NativeClass
	    {
	    public:
	        static void DoSomething()
		    {
			    Console::WriteLine("IntPtr.Size = {0}", IntPtr::Size);
		    }
	    };
    }
