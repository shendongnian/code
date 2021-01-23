    public class Program 
    { 
        private static bool m_Stop = false; 
     
        public static void Main(string[] args) 
        { 
            var thread = new Thread( 
                () => 
                { 
                    int i = 0; 
                    Console.WriteLine("begin"); 
                    while (!m_Stop) 
                    { 
                        i++; 
                    } 
                    Console.WriteLine("end"); 
                }); 
            thread.Start(); 
            Thread.Sleep(1000); 
            m_Stop = true; 
            Console.WriteLine("exit"); 
        } 
    } 
