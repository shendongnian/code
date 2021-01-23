    #if WIN64
         long handle;
         public bool SomeFunction(long windowHandle)
    #else
         int handle;
         public bool SomeFunction(int windowHandle)
    #endif
