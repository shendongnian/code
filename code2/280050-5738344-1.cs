    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace Test
    {
        public class MyGeneric<T> // removed "where T : class"
        {
            public void Print(params T[] vals)
            {
                Print((IEnumerable<T>) vals);
            }
            public void Print(IEnumerable<T> vals)
            {
                foreach (var v in vals.OfType<T>()) // use "OfType" instead of "Where"
                {
                    Trace.WriteLine(v.ToString());
                }
                Trace.WriteLine(string.Empty);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                MyGeneric<string> foo = new MyGeneric<string>();
                foo.Print("a", "b", "c", null, null, "g");
            }
        }
    }
