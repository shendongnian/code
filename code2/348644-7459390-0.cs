    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int iterations = 1000000;
                const long target = 7192;
                var arr = Enumerable.Range(0, 10000).Select(i => (long)i).ToArray();
                var list = arr.ToList();
    
                bool result;
    
                var arr0 = Stopwatch.StartNew();
                for (var i = 0; i < iterations; i++)
                {
                    result = LinearSearchArr(arr, target);
                }
                arr0.Stop();
    
                var arr1 = Stopwatch.StartNew();
                for (var i = 0; i < iterations; i++)
                {
                    // actually Enumerable.Contains()
                    result = arr.Contains(target);
                }
                arr1.Stop();
    
                var arr2 = Stopwatch.StartNew();
                for (var i = 0; i < iterations; i++)
                {
                    result = ((IList<long>)arr).Contains(target);
                }
                arr2.Stop();
    
                var arr3 = Stopwatch.StartNew();
                for (var i = 0; i < iterations; i++)
                {
                    result = ((IEnumerable<long>)arr).Contains(target);
                }
                arr3.Stop();
    
                var arr4 = Stopwatch.StartNew();
                for (var i = 0; i < iterations; i++)
                {
                    result = ((ICollection<long>)arr).Contains(target);
                }
                arr4.Stop();
    
                var list0 = Stopwatch.StartNew();
                for (var i = 0; i < iterations; i++)
                {
                    result = LinearSearchList(list, target);
                }
                list0.Stop();
    
                var list1 = Stopwatch.StartNew();
                for (var i = 0; i < iterations; i++)
                {
                    result = list.Contains(target);
                }
                list1.Stop();
    
                var list2 = Stopwatch.StartNew();
                for (var i = 0; i < iterations; i++)
                {
                    result = ((IList<long>)list).Contains(target);
                }
                list2.Stop();
    
                var list3 = Stopwatch.StartNew();
                for (var i = 0; i < iterations; i++)
                {
                    result = ((IEnumerable<long>)list).Contains(target);
                }
                list3.Stop();
    
                var list4 = Stopwatch.StartNew();
                for (var i = 0; i < iterations; i++)
                {
                    result = ((ICollection<long>)list).Contains(target);
                }
                list4.Stop();
    
                Console.WriteLine("array linear {0} ({1})", arr0.Elapsed, arr0.ElapsedTicks);
                Console.WriteLine("array pure {0} ({1})", arr1.Elapsed, arr1.ElapsedTicks);
                Console.WriteLine("array as IList {0} ({1})", arr2.Elapsed, arr2.ElapsedTicks);
                Console.WriteLine("array as IEnumerable {0} ({1})", arr3.Elapsed, arr3.ElapsedTicks);
                Console.WriteLine("array as ICollection {0} ({1})", arr4.Elapsed, arr4.ElapsedTicks);
                Console.WriteLine("list linear {0} ({1})", list0.Elapsed, list0.ElapsedTicks);
                Console.WriteLine("list pure {0} ({1})", list1.Elapsed, list1.ElapsedTicks);
                Console.WriteLine("list as IList {0} ({1})", list2.Elapsed, list2.ElapsedTicks);
                Console.WriteLine("list as IEnumerable {0} ({1})", list3.Elapsed, list3.ElapsedTicks);
                Console.WriteLine("list as ICollection {0} ({1})", list4.Elapsed, list4.ElapsedTicks);
            }
    
            static bool LinearSearchArr(long[] arr, long target)
            {
                for (var i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == target)
                    {
                        return true;
                    }
                }
                return false;
            }
    
            static bool LinearSearchList(List<long> list, long target)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    if (list[i] == target)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
