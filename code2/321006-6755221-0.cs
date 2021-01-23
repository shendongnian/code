    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Dynamic;
    namespace ConsoleApplication1
    {
      class Program
      {
         static void Main(string[] args)
         {
            var source1 = new
            {
                foo = "foo",
                bar = "bar"
            };
            var source2 = new
            {
               baz = "baz"
            };
            dynamic merged = Merge(source1, source2);
            Console.WriteLine("{0} {1} {2}", merged.foo, merged.bar, merged.baz);
         }
         static MergedType<T1, T2> Merge<T1, T2>(T1 t1, T2 t2)
         {
            return new MergedType<T1, T2>(t1, t2);
         }
      }
      class MergedType<T1, T2> : DynamicObject
      {
         T1 t1;
         T2 t2;
         Dictionary<string, object> members = new Dictionary<string, object>();
         public MergedType(T1 t1, T2 t2)
         {
            this.t1 = t1;
            this.t2 = t2;
            foreach (System.Reflection.PropertyInfo fi in typeof(T1).GetProperties())
            {
               members[fi.Name] = fi.GetValue(t1, null);
            }
            foreach (System.Reflection.PropertyInfo fi in typeof(T2).GetProperties())
            {
               members[fi.Name] = fi.GetValue(t2, null);
            }
         }
         public override bool TryGetMember(GetMemberBinder binder, out object result)
         {
            string name = binder.Name.ToLower();
            return members.TryGetValue(name, out result);
         }
      }
    }
