    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NS;
    
    namespace Tests
    {
    [TestClass]
    public class DataReunionTest
    {
        [TestMethod]
        public void Test()
        {
            List<Tuple<Int32, Int32, String>> A = new List<Tuple<Int32, Int32, String>>();
            List<Tuple<Int32, Int32, String>> B = new List<Tuple<Int32, Int32, String>>();
            Random rnd = new Random();
            /* Comment the testing block you do not want to run
            /* Solution to test a wide range of keys*/
            for (int i = 0; i < 500; i += 1)
            {
                A.Add(Tuple.Create(rnd.Next(1, 101), rnd.Next(1, 101), "A"));
                B.Add(Tuple.Create(rnd.Next(1, 101), rnd.Next(1, 101), "B"));
            }
            /* Solution for essential testing*/
            A.Add(Tuple.Create(1, 2, "B11"));
            A.Add(Tuple.Create(1, 2, "B12"));
            A.Add(Tuple.Create(1, 3, "C11"));
            A.Add(Tuple.Create(1, 3, "C12"));
            A.Add(Tuple.Create(1, 3, "C13"));
            A.Add(Tuple.Create(1, 4, "D1"));
            B.Add(Tuple.Create(1, 1, "A21"));
            B.Add(Tuple.Create(1, 1, "A22"));
            B.Add(Tuple.Create(1, 1, "A23"));
            B.Add(Tuple.Create(1, 2, "B21"));
            B.Add(Tuple.Create(1, 2, "B22"));
            B.Add(Tuple.Create(1, 2, "B23"));
            B.Add(Tuple.Create(1, 3, "C2"));
            B.Add(Tuple.Create(1, 5, "E2"));
            Func<Tuple<Int32, Int32, String>, Tuple<Int32, Int32>> key = (_) => Tuple.Create(_.Item1, _.Item2);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = DataReunion.FullJoin(A, key, B, key);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            String aser = JToken.FromObject(res).ToString(Formatting.Indented);
            Console.Write(elapsedMs);
        }
    }
}
