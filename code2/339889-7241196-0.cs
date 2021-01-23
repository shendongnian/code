    using System;
    using System.Collections;
    
    class Program
    {
        static void Main()
        {
            ArrayList list = new ArrayList();
            list.Add("a");
            list.Add("b");
            
            ArrayList view1 = list.GetRange(0, 1);
            ArrayList view2 = list.GetRange(1, 1);
            
            view1[0] = "c";
            Console.WriteLine(view2[0]); // Throws an exception
        }
    }
