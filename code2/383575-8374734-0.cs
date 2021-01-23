        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);
        [DllImport("yourlibrary.dll")]
        public static extern void Foo();
        public void CallTheFooMethod()
        {
           // first load the library
           LoadLibrary( "C:/..........full path/yourlibrary.dll" );
           Foo();  
        }
