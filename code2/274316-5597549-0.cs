    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization.Json;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<int, List<int>> foo = new Dictionary<int, List<int>>();
    
                foo.Add(1, new List<int>( new int[] { 1, 2, 3, 4 }));
                foo.Add(2, new List<int>(new int[] { 2, 3, 4, 1 }));
                foo.Add(3, new List<int>(new int[] { 3, 4, 1, 2 }));
                foo.Add(4, new List<int>(new int[] { 4, 1, 2, 3 }));
    
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<int, List<int>>));
    
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, foo);
                    Console.WriteLine(Encoding.Default.GetString(ms.ToArray()));
                }
            }
        }
    }
