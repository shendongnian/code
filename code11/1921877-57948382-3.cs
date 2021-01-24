    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace ConsoleApp6 {
        class Program {
            static void Main(string[] args) {
                var enumerable = Enumerable.Range(0, 5_000_000);
    
                var sw = new Stopwatch();
                sw.Start();
    
                var oldSingle = enumerable.PickRandomOld();
    
                Console.WriteLine($"Old single took: {sw.Elapsed.ToString()}");
                sw.Restart();
    
                var oldMultiple = enumerable.PickRandomOld(2000).ToList();
    
                Console.WriteLine($"Old multiple took: {sw.Elapsed.ToString()}");
                sw.Restart();
                var orderBySingle = enumerable.PickRandomOrderBy(2000).ToList();
                Console.WriteLine($"OrderBy took: {sw.Elapsed.ToString()}");
                sw.Restart();
    
                var newSingle = enumerable.PickRandom();
    
                Console.WriteLine($"New single took: {sw.Elapsed.ToString()}");
                sw.Restart();
    
                var newMultiple = enumerable.PickRandom(2000).ToList();
    
                Console.WriteLine($"New multiple took: {sw.Elapsed.ToString()}");
                sw.Stop();
    
                Console.ReadLine();
            }
        }
    
        public static class EnumerableExtension {
    
            private static Random _random = new Random(DateTime.UtcNow.Millisecond);
    
            public static T PickRandomOld<T>(this IEnumerable<T> source) {
                return source.PickRandomOld(1).Single();
            }
    
            public static IEnumerable<T> PickRandomOld<T>(this IEnumerable<T> source, int count) {
                return source.Shuffle().Take(count);
            }
            public static IEnumerable<T> PickRandomOrderBy<T>(this IEnumerable<T> source, int count) {
                 return source.OrderBy(n => _random.Next()).Take(count);
            }
    
            private static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) {
                return source.OrderBy(x => System.Guid.NewGuid());
            }
    
            public static T PickRandom<T>(this IEnumerable<T> source) {
                var indexLessThan = source.Count() - 1;
    
                var skip = _random.Next(indexLessThan);
    
                return skip == 0 ? source.First() : source.Skip(skip).First();
            }
    
            public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count) {
                var indexLessThan = source.Count();
    
                var usedIndexes = new HashSet<int>(count);
    
    
                do {
                    if(usedIndexes.Add(_random.Next(indexLessThan))) {
                        count--;
                    }
                } while (count > 0);
    
                return source.Where((x, i) => usedIndexes.Contains(i));
            }
        }
    }
