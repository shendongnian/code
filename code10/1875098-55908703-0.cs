    using System;
    using System.Collections.Generic;
    
    namespace LinkedListSwap
    {
        class Program
        {
            static void Main(string[] args)
            {
                var list = new LinkedList<string>(new[] { "1st", "2nd", "3rd", "4th", "5th", "6th", "7th" });
                Console.WriteLine(list.ToDisplayString());
                list.Swap(2, 3);
                Console.WriteLine(list.ToDisplayString());
            }
        }
    
        static class LinkedListExtensions
        {
            public static void Swap<T>(this LinkedList<T> list, int firstIndex, int secondIndex)
            {
                if (firstIndex < 1 || firstIndex > list.Count)
                    throw new IndexOutOfRangeException($"Index out of range: {nameof(firstIndex)}");
    
                if (secondIndex < 1 || secondIndex > list.Count)
                    throw new IndexOutOfRangeException($"Index out of range: {nameof(secondIndex)}");
    
                if (firstIndex == secondIndex)
                    return;
    
                if (firstIndex > secondIndex)
                    (firstIndex, secondIndex) = (secondIndex, firstIndex);
    
                int i = 0;
    
                var leftNode = list.First;
                while (++i < firstIndex)
                    leftNode = leftNode.Next;
    
                var rightNode = leftNode.Next;
                while (++i < secondIndex)
                    rightNode = rightNode.Next;
    
                list.Replace(leftNode, rightNode);
                list.Replace(rightNode, leftNode);
            }
    
            public static void Replace<T>(this LinkedList<T> list, LinkedListNode<T> oldNode, LinkedListNode<T> newNode)
            {
                list.AddAfter(oldNode, new LinkedListNode<T>(newNode.Value));
                list.Remove(oldNode);
            }
    
            public static string ToDisplayString<T>(this LinkedList<T> list) => string.Join(" ", list);
        }
    }
