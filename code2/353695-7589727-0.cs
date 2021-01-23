    using System;
    namespace RandomTest
    {
        public class Dictionary
        {
            private Random m_RandomGenerator = new Random();
            public int GetNext()
            {
                return m_RandomGenerator.Next(100);
            }
        } 
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary d = new Dictionary();
                for (int i=0;i<10;i++)
                {
                    int r = d.GetNext();
                    Console.Write("{0} ",r);
                }
                Console.WriteLine();
            }
        }
    }
