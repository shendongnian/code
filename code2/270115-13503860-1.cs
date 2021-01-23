    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    static class Program
    {
        static void Main(string[] args)
        {
            var ax = new[] { 
                new { id = 1, name = "John" },
                new { id = 2, name = "Sue" } };
            var bx = new[] { 
                new { id = 1, surname = "Doe" },
                new { id = 3, surname = "Smith" } };
    
            var ad = ax.GroupBy(a => a.id, a => a.name)   .ToDictionary(g => g.Key, g => g.AsEnumerable());
            var bd = bx.GroupBy(b => b.id, b => b.surname).ToDictionary(g => g.Key, g => g.AsEnumerable());
    
            var ids = ad.Keys.Union(bd.Keys);
    
            var j = from id in ids
                    from a in ad.OuterGet(id, "n/a")
                    from b in bd.OuterGet(id, "n/a")
                    select new { id, a, b };
                    
            j.ToList().ForEach(Console.WriteLine);
        }
    
        private static IEnumerable<V> OuterGet<K, V>(this IDictionary<K, IEnumerable<V>> dict, K k, V d=default(V))
        {
            IEnumerable<V> result;
            if (dict.TryGetValue(k, out result))
                return result;
            return new [] { d };
        }
    }
