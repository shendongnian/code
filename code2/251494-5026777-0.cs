    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace EnumTester
    {
        class Program
        {
            static void Main(string[] args)
            {
                 IEnumerable<string> enum = GetObjectEnumerable();
                 
                 IEnumerable<string> concatenated = enum.Concat(new List<string> { "concatenated" });
                 
                 List<string> stringList = concatenated.ToList();
            }
        }
    }
