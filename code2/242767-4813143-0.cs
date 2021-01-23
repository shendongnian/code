    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace InOutRef
    {
        static class InOutRef
        {
            public static void In(int i)
            {
                Console.WriteLine(i);
                i=100;
                Console.WriteLine(i);
            }
            public static void Ref(ref int i)
            {
                Console.WriteLine(i);
                i=200;
                Console.WriteLine(i);
            }
            public static void Out(out int i)
            {
                //Console.WriteLine(i); //Error Unsigned Ref
                i=300;
                Console.WriteLine(i);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                int i = 1;
                InOutRef.In(i); //reference doesnt change like java
                Debug.Assert(i==1);
                InOutRef.Ref(ref i); //reference changes like vb.net ref
                Debug.Assert(i == 200);
                InOutRef.Out(out i); //must be reassigned before it leaves
                Debug.Assert(i == 300);
            }
        }
    }
