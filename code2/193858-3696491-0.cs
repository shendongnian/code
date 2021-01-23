    using System;
    using System.Linq;
    using System.Reflection;
    public class Merger
    {
        public static TTarget Merge<TTarget>(object copyFrom) where TTarget : new()
        {
            var flags = BindingFlags.Instance | BindingFlags.Public |
                        BindingFlags.NonPublic;
            var targetDic = typeof(TTarget).GetFields(flags)
                                           .ToDictionary(f => f.Name);
            var ret = new TTarget();
            foreach (var f in copyFrom.GetType().GetFields(flags))
            {
                if (targetDic.ContainsKey(f.Name))
                    targetDic[f.Name].SetValue(ret, f.GetValue(copyFrom));
                else
                    throw new InvalidOperationException(string.Format(
                        "The field “{0}” has no corresponding field in the type “{1}”.",
                        f.Name, typeof(TTarget).FullName));
            }
            return ret;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A { prop1 = "one", prop2 = 2, propX = 127, propY = 0.47f };
            var c = Merger.Merge<C>(a);
            Console.WriteLine(c.prop1);  // prints one
            Console.WriteLine(c.prop2);  // prints 2
            Console.WriteLine(c.propX);  // prints 127
            Console.WriteLine(c.propY);  // prints 0.47
        }
    }
