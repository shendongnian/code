      class MainClass
        {
                //Constants from /usr/include/bits/dlfcn.h
                private const int RTLD_LAZY = 0x00001; //Only resolve symbols as needed
                private const int RTLD_GLOBAL = 0x00100; //Make symbols available to libraries loaded later
                [DllImport("dl")]
                private static extern IntPtr dlopen (string file, int mode);
                
                [DllImport("a")]
                private static extern void f ();
                
                public static void Main (string[] args)
                {
                        //Load libb. RTLD_LAZY could be replaced with RTLD_NOW, but
                        //RTLD_GLOBAL is essential
                        dlopen("libb.so", RTLD_LAZY|RTLD_GLOBAL);
                        //Call f(), no unresolved symbol problem!
                        f();
                }
        }
