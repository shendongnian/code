    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        public interface INode { 
            INode Left { get; set; }
            INode Right { get; set; }
            T GetValue<T>();
            object Clone();
        }
    
        public class Node<T> : ICloneable, INode where T : class
        {
            public INode Left { get; set; }
            public INode Right { get; set; }
            public T Value { get; set; }
    
            public TRet GetValue<TRet>() {
                return (TRet)(Object)Value;
            }
    
            public Node(Node<T> left, Node<T> right, T value)
            {
                this.Left = left;
                this.Right = right;
                this.Value = value;
            }
    
            public Node(T value)
            {
                this.Value = value;
            }
    
            public override string ToString()
            {
                return Value.ToString();
            }
    
            public object Clone()
            {
                return new Node<T>(this.Value);
            }
        }
    
        public static class Extensions
        {
            public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> list)
            {
                return list.Permute<T>(list.Count());
            }
    
            public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> list, int count)
            {
                if (count == 0)
                {
                    yield return new T[0];
                }
                else
                {
                    int startingElementIndex = 0;
                    foreach (T startingElement in list)
                    {
                        IEnumerable<T> remainingItems = AllExcept(list, startingElementIndex);
    
                        foreach (IEnumerable<T> permutationOfRemainder in Permute(remainingItems, count - 1))
                        {
                            yield return Concat<T>(
                                new T[] { startingElement },
                                permutationOfRemainder);
                        }
                        startingElementIndex += 1;
                    }
                }
            }
    
            // Enumerates over contents of both lists.
            public static IEnumerable<T> Concat<T>(IEnumerable<T> a, IEnumerable<T> b)
            {
                foreach (T item in a) { yield return item; }
                foreach (T item in b) { yield return item; }
            }
    
            // Enumerates over all items in the input, skipping over the item
            // with the specified offset.
            public static IEnumerable<T> AllExcept<T>(IEnumerable<T> input, int indexToSkip)
            {
                int index = 0;
                foreach (T item in input)
                {
                    if (index != indexToSkip) yield return item;
                    index += 1;
                }
            }
    
            public static void ConnectCycle<T>(this IList<T> nodes) where T : class, INode
            {
                foreach (var node in nodes)
                {
                    var nn2 = nodes.FirstOrDefault(n => n.Left == null && n.Right == null && n != node);
    
                    if (nn2 != default(T))
                    {
                        if (node.Right == null)
                        {
                            node.Right = nn2;
                            nn2.Left = node;
                        }
                    }
                    else
                    {
                        var nn1 = nodes.FirstOrDefault(n => (n.Left == null || n.Right == null) && n != node);
                        if (nn1 != default(T))
                        {
                            if (node.Right == null)
                            {
                                node.Right = nn1;
                                nn1.Left = node;
                            }
                        }
                        else
                        {
                            if (nodes.FirstOrDefault(n => n.Left == null || n.Right == null) != default(T))
                            {
                                node.Right = nodes.First(n => n.Left == node);
                            }
                            else {
                                break; // finished
                            }
                        }
                    }
                }
            }
    
            public static void DisconnectCycle<T>(this IList<T> list) where T : class, INode
            {
                foreach (var node in list) {
                    node.Left = null;
                    node.Right = null;
                }
            }
    
            public static Sequence<T, U> Clone<T, U>(this IList<T> list) where T : class, INode where U : class
            {
                Sequence<T, U> newList = new Sequence<T, U>();
    
                /* this block copies the ordered circle graph into a sequence starting from the first node */
                var start = list[list.Count - 1];
                var next = start;
                bool loopdone = false;
                if (next.Right == null) // disocnnected, add in default order
                {
                    foreach (var n in list) {
                        newList.Add(n.Clone() as T);
                    }
                }
                else  // connected, add in order of connection
                {
                    while ((next = next.Right as T) != start.Right || !loopdone)
                    {
                        newList.Add((next as T).Clone() as T);
                        loopdone = true;
                    }
                }
    
                /* this block connects the links Left/Right of the new list */
                for (int i = 0; i < newList.Count; i++)
                {
                    if (i > 0)
                    {
                        newList[i].Left = newList[i - 1];
                    }
                    if (i < newList.Count - 1)
                    {
                        newList[i].Right = newList[i + 1];
                    }
                }
                newList[0].Left = newList[newList.Count - 1]; // connect first to last
                newList[newList.Count - 1].Right = newList[0]; // connect last to first
    
                return newList;
            }
        }
    
        public class Sequence<T, U> : List<T> where T : class, INode where U : class
        {
            private List<Sequence<Node<U>, U>> okSequences;
            private Random random;
            
            public Sequence() {
                okSequences = new List<Sequence<Node<U>, U>>();
                random = new Random(DateTime.Now.Millisecond);
            }
    
            public Sequence(int? seed) {
                okSequences = new List<Sequence<Node<U>, U>>();
                random = new Random(seed ?? DateTime.Now.Millisecond);
            }
    
            public string ToString<TNodeType>()
            {
                string ret = String.Empty;
    
                // just write down nodes in sequence plus previous/next in []
                foreach (var item in this) {
                    ret += item.GetValue<TNodeType>().ToString() + "[" + item.Left.GetValue<TNodeType>().ToString() + "/" + item.Right.GetValue<TNodeType>().ToString() + "], "; 
                }
    
                ret = ret.Remove(ret.Length - 2, 2); // remove trailing ", "
    
                return ret;
            }
    
            public void Shuffle() {
                this.DisconnectCycle();
                var permutations = this.Permute();
    
                foreach (var permutation in permutations)
                {
                    bool cycleOk = true;
                    var cycle = permutation.ToList().Clone<T,U>();
                    cycle.ConnectCycle();
                    var start = cycle[cycle.Count - 1];
                    INode next = start;
                    while ((next = next.Right) != start)
                    {
                        if (next.GetValue<U>() == next.Right.GetValue<U>() ||
                            next.GetValue<U>() == next.Right.Right.GetValue<U>() ||
                            next.GetValue<U>() == next.Left.GetValue<U>() ||
                            next.GetValue<U>() == next.Left.Left.GetValue<U>())
                            cycleOk = false;
                    }
                    if (cycleOk)
                    {
                        okSequences.Add(cycle.Clone<T,U>() as Sequence<Node<U>, U>);
                    }
                }
            }
    
            public bool IsValid {
                get {
                    return okSequences.Count > 0;
                }
            }
    
            public int Unique {
                get {
                    return okSequences.Count;
                }
            }
    
            public void Reset() {
                okSequences = new List<Sequence<Node<U>, U>>();
            }
    
            public Sequence<T, U> GetRandom(int? seed) {
    
                if (!IsValid) return null;
    
                int next = random.Next(okSequences.Count);
    
                return okSequences[next] as Sequence<T, U>;
            }
        }
    
        static class Program
        {
    
            public static void Main(string[] Args)
            {
                // must repeat the string string to be able to do a typesafe generic
                // if you don't give the same type it will explode
                Sequence<Node<string>, string> nodes = new Sequence<Node<string>, string>();
                // fill nodes / letters integers or whatever
                nodes.Add(new Node<string>("a"));
                nodes.Add(new Node<string>("b"));
                nodes.Add(new Node<string>("c"));
                nodes.Add(new Node<string>("d"));
                nodes.Shuffle(); // shuffle the list
    
                if (nodes.IsValid)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        // get some randoms
                        var seq = nodes.GetRandom(null);
                        Debug.WriteLine("Got random shuffle : " + seq.ToString<string>());
                    }
                }
                else {
                    Debug.WriteLine("Sequence is not valid after trying shuffle.");
                }
    
            }
        }
    }
