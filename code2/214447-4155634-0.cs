    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Accepted", "ACC");
            d.Add("Rejected", "REJ");
    
            string r = d["Rejected"];
        }
    }
