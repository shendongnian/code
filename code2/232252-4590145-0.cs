    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Merge
    {
        class Program
        {
            static IEnumerable<T> Merge<T>(IEnumerable<T> left, IEnumerable<T> right)
                where T: IComparable<T>
            {
                IEnumerator<T> l = left.GetEnumerator();
                IEnumerator<T> r = right.GetEnumerator();
    
                bool l_has_data = l.MoveNext();
                bool r_has_data = r.MoveNext();
    
                while (l_has_data || r_has_data)
                {
                    if (!l_has_data && r_has_data)
                    {
                        yield return r.Current;
                        r_has_data = r.MoveNext();
                        continue;
                    }
                    if (!r_has_data && l_has_data)
                    {
                        yield return l.Current;
                        l_has_data = l.MoveNext();
                        continue;
                    }
    
                    int comp = l.Current.CompareTo(r.Current);
                    if (comp < 0)
                    {
                        yield return l.Current;
                        l_has_data = l.MoveNext();
                    }
                    else if (comp > 0)
                    {
                        yield return r.Current;
                        r_has_data = r.MoveNext();
                    }
                    else
                    {
                        yield return l.Current;
                        yield return r.Current;
                        l_has_data = l.MoveNext();
                        r_has_data = r.MoveNext();
                    }
                }
            }
    
            static void Main(string[] args)
            {
                var left = new[] { 1, 4, 7, 9, 10 };
                var right = new[] { 1, 2, 3, 6, 8, 9, 11 };
    
                foreach (var i in Merge(left, right))
                    Console.WriteLine(i);
            }
        }
    }
