    static void Main(string[] args)
    {
            int G;
            int [] A=new int [2];
            Stack st = new Stack();
    
            for (G = 0; G < 5; G++)
            {
                A[0] = G;
                A[1] = G;
    
    
                st.Push(A);
            }
    
            foreach (Object obj in st)
            {
                Console.WriteLine(string.Join("", (int[])obj));
            }
    
            Console.ReadKey();
    }
