    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication6
    {
        class TempRecord
        {
            // Array of temperature values 
            private float[] temps = new float[10] { 56.2F, 56.7F, 56.5F, 56.9F, 58.8F, 61.3F, 65.9F, 62.1F, 59.2F, 57.5F }; private int[] d = new int[10] { 4, 5, 5, 4, 4, 43, 2, 2, 5, 3 };
    
            public int Length //
            {
                get { return temps.Length; }
            }
            public float this[int index]
            {
                get { return temps[index]; }
    
                set { temps[index] = value; }
            }
            public int this[int index]
            {
                get
                {
                    return d[index];
                }
    
                set
                {
                    d[index] = value;
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                TempRecord tempRecord = new TempRecord();
                tempRecord[3] = 58.3F;
                tempRecord[5] = 60.1F;
    
                
                for (int i = 0; i < 10; i++)
                {
                    System.Console.WriteLine("Element #{0} = {1}", i, tempRecord[i]);
                }
                Console.WriteLine(tempRecord[2]);
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
    
            }
        }
    }
