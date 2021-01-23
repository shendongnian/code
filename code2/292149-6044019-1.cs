    using System.Runtime.InteropServices;
    
    namespace CallDelphiDll
    {
      class Program
      {
        static void Main(string[] args)
        {
          SayHello();
        }
    
        [DllImport("DllDemo")]
        static extern void SayHello();
      }
    }
