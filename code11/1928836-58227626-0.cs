    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace Beee
        {
            public class SampleProgram
            {
                public static void Main(string[] args)
                {
                    object[] o = new object[] {"1", 4.0, "Abuja", 'B'};
                    fun(o);
                }
                static void fun(params object[] obj)
                {
                    for(int i=0; i<obj.Length-1; i++)
                    Console.Write(obj[i] +"");
                }
            }
    }
