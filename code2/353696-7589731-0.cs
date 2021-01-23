    namespace Sandbox
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary dict = new Dictionary();
                for (int count = 0; count < 100; count++)
                    Console.WriteLine(dict.GetNext());
                Console.ReadLine();
            }
        }
    
        public class Dictionary
        {
            private Random m_RandomGenerator = new Random();
    
            public int GetNext()
            {
                return m_RandomGenerator.Next(100);
            }
        }
    }
