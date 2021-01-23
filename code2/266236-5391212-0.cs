    using System;
    
    class Test
    {
        static void Main()
        {
            string currTime = DateTime.Now.ToString("u");
            currTime = currTime.Substring(0, currTime.Length - 1);
            currTime = currTime + ".000";
            Console.WriteLine(currTime);
        }
    }    
