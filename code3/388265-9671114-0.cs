    using System;
    using System.Collections.Generic;
    namespace Quickie
    {
        class QuickieArray
        {
            private static void TestCastIDictionaryWithArrayValue()
            {
                Console.WriteLine();
                Console.WriteLine("===TestCastIDictionaryWithArrayValue===");
                IDictionary<int, IEnumerable<string>> d1 = new Dictionary<int, IEnumerable<string>>();
                d1[1] = new string[] { "foo" };
                IDictionary<int, IEnumerable<string>> id1 = d1;
                Console.WriteLine("id1 is null: {0}", id1 == null);
                IDictionary<int, IEnumerable<string>> ide1 = id1 as IDictionary<int, IEnumerable<string>>;
                IDictionary<int, IEnumerator<string>> iden1 = id1 as IDictionary<int, IEnumerator<string>>;
                Console.WriteLine("ide1 is null: {0}", ide1 == null);
                Console.WriteLine("iden1 is null: {0}", iden1 == null);
                Console.WriteLine();
            }
            internal static void Test()
            {
                Console.WriteLine();
                TestCastIDictionaryWithArrayValue();
            }
        }
    }
