    using ClassLibraryB;
    namespace ConsoleApplication1
    {
        public static class Extensions
        {
            public static int Test(this int a)
            {
                return a;
            }
        }
        public class ProgramA
        {
            static void Main(string[] args)
            {
                0.Test();
            }
        }
    }
