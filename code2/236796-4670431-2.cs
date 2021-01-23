     class Program
     {
           [DllImport("UnmanagedCpp.dll")]
           public static extern void Dummy();
    
            static void Main(string[] args)
            {
                
                Dummy();
            }
     }
