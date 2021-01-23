    using System;
    
    namespace TestArrayCompare
    {
        class Program
        {
            static bool AreEqual(byte[] a1, byte[] a2)
            {
                bool result = true;
                for (int i = 0; i < a1.Length; ++i)
                {
                    if (a1[i] != a2[i])
                        result = false;
                }
                return result;
            }
    
            static void Main(string[] args)
            {
                byte[] a1 = new byte[100];
                byte[] a2 = new byte[100];
                if (AreEqual(a1, a2))
                {
                    Console.WriteLine("`a1' equals `a2'.");
                }
                else
                {
                    Console.WriteLine("`a1' does not equal `a2'.");
                }
            }
        }
    }
