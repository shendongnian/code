    class CSharpCode : IDisposible
    {
        delegate void CallbackDelegate();
        GCHandle gchCallbackDelegate;
    
        void DoCSharp()
        {
            CallbackDelegate callbackDelegate = TheCallback;
            IntPtr callbackDelegatePointer = Marshal.GetFunctionPointerForDelegate(callbackDelegate);
            gchCallbackDelegate = GCHandle.Alloc(callbackDelegate); // !!!!
    
            GC.Collect(); // create max space for unmanaged allocations
            CppCliCode.DoCppCli(callbackDelegatePointer);
        }
    
        public void Dispose()
        {
            CleanUp();
        }
    
        ~CSharpCode()
        {
            CleanUp();
        } 
    
        CleanUp()
        {
            if(gchCallbackDelegate.IsAllocated)
                gchCallbackDelegate.Free();
        }
    
    
    }
