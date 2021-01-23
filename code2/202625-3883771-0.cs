    public static class A
    {
        public static class B
        {
            public static string c
            {
                get
                {
                    return "hi";
                }
            }
        }
    }
    class Program
    {
        static void Main( string[] args )
        {
            
            Console.WriteLine(typeof(A.B).FullName.Replace("+",".") + "." +  A.B.c  ) ;
        }
     
    }
