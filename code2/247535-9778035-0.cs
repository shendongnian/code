    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace OrderedJoin
    {
        public static class EnumerableExtension
        {
            private enum JoinType
            {
                Inner,
                Left,
                Right,
                Full
            }
    
            private static IEnumerable<TResult> OrderedJoinIterator<T, TResult>(
                this IEnumerable<T> left, IEnumerable<T> right, Func<T, T, TResult> resultSelector, JoinType jt, IComparer<T> comparer)
            {
                if (left == null) throw new ArgumentNullException("left");
                if (right == null) throw new ArgumentNullException("right");
                if (resultSelector == null) throw new ArgumentNullException("resultSelector");
    
                if (comparer == null)
                    comparer = Comparer<T>.Default;
    
                var l = left.GetEnumerator();
                var r = right.GetEnumerator();
    
                var lHasData = l.MoveNext();
                var rHasData = r.MoveNext();
    
                while (lHasData || rHasData)
                {
                    if (!lHasData && rHasData)
                    {
                        if (jt == JoinType.Inner || jt == JoinType.Left)
                            yield break;
                        yield return resultSelector(default(T), r.Current);
                        rHasData = r.MoveNext();
                        continue;
                    }
                    if (!rHasData && lHasData)
                    {
                        if (jt == JoinType.Inner || jt == JoinType.Right)
                            yield break;
                        yield return resultSelector(l.Current, default(T));
                        lHasData = l.MoveNext();
                        continue;
                    }
    
                    var comp = comparer.Compare(l.Current, r.Current);
    
                    if (comp < 0)
                    {
                        if (jt == JoinType.Left || jt == JoinType.Full)
                            yield return resultSelector(l.Current, default(T));
                        lHasData = l.MoveNext();
                    }
                    else if (comp > 0)
                    {
                        if (jt == JoinType.Right || jt == JoinType.Full)
                            yield return resultSelector(default(T), r.Current);
                        rHasData = r.MoveNext();
                    }
                    else
                    {
                        yield return resultSelector(l.Current, r.Current);
                        lHasData = l.MoveNext();
                        rHasData = r.MoveNext();
                    }
                }
            }
    
            public static IEnumerable<TResult> OrderedInnerJoin<T, TResult>(
                this IEnumerable<T> left, IEnumerable<T> right, Func<T, T, TResult> resultSelector, IComparer<T> comparer = null)
            {
                return OrderedJoinIterator(left, right, resultSelector, JoinType.Inner, comparer);
            }
    
            public static IEnumerable<TResult> OrderedFullJoin<T, TResult>(
                this IEnumerable<T> left, IEnumerable<T> right, Func<T, T, TResult> resultSelector, IComparer<T> comparer = null)
            {
                return OrderedJoinIterator(left, right, resultSelector, JoinType.Full, comparer);
            }
    
            public static IEnumerable<TResult> OrderedLeftJoin<T, TResult>(
                this IEnumerable<T> left, IEnumerable<T> right, Func<T, T, TResult> resultSelector, IComparer<T> comparer = null)
            {
                return OrderedJoinIterator(left, right, resultSelector, JoinType.Left, comparer);
            }
    
            public static IEnumerable<TResult> OrderedRightJoin<T, TResult>(
                this IEnumerable<T> left, IEnumerable<T> right, Func<T, T, TResult> resultSelector, IComparer<T> comparer = null)
            {
                return OrderedJoinIterator(left, right, resultSelector, JoinType.Right, comparer);
            }
        }
    
        internal class TestEnum : IEnumerable<int>
        {
            public TestEnum(string name, IList<int> nums)
            {
                Name = name;
                Nums = nums;
            }
    
            public string Name { get; private set; }
            public IList<int> Nums { get; private set; }
    
            public IEnumerator<int> GetEnumerator()
            {
                foreach (var item in Nums)
                {
                    Console.WriteLine("{0}: {1}", Name, item);
                    yield return item;
                }
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var e1 = new TestEnum("L", new List<int> { 1, 2, 5, 6 });
                var e2 = new TestEnum("R", new List<int> { 1, 3, 4, 6 });
    
                var print = new Action<IEnumerable<string>>(seq => { foreach (var item in seq) Console.WriteLine("\t" + item); });
    
                Console.WriteLine("Standard Inner Join:");
                print(e1.Join(e2, i => i, j => j, (i, j) => string.Format("{0} <=> {1}", i, j), EqualityComparer<int>.Default));
    
                Console.WriteLine("Ordered Inner Join:");
                print(e1.OrderedInnerJoin(e2, (i, j) => string.Format("{0} <=> {1}", i, j)));
    
                Console.WriteLine("Ordered Full Join:");
                print(e1.OrderedFullJoin(e2, (i, j) => string.Format("{0} <=> {1}", i, j)));
    
                Console.WriteLine("Ordered Left Join:");
                print(e1.OrderedLeftJoin(e2, (i, j) => string.Format("{0} <=> {1}", i, j)));
    
                Console.WriteLine("Ordered Right Join:");
                print(e1.OrderedRightJoin(e2, (i, j) => string.Format("{0} <=> {1}", i, j)));
    
                Console.ReadLine();
            }
        }
    }
