    using System;
    
    delegate void ByRef(ref string x);
    delegate void ByOut(out string x);
    
    class Test
    {
        static void Main()
        {
            ByRef r = (ref string x) => { x = null; };
            
            string tmp = "Not null";
            r(ref tmp);
            Console.WriteLine(tmp == null); // True
            
            ByOut o = (out string x) => { x = null; };
            
            string tmp2;
            o(out tmp2);
            Console.WriteLine(tmp2 == null); // True
            
        }
    }
