    using System;
    
    public class Test 
    {
        public static void Main()
        {
            byte[] bytes = new byte[12];
            float[] floats = { 1.5f, 2.5f, 0.000001f };
            
            Buffer.BlockCopy(floats, 0, bytes, 0, 12);
            
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine("{0}: {1}", i, bytes[i]);
            }
        }
    }
