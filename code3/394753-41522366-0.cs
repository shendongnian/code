    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ReverseLinkedList
    {
        class Program
        {
            static void Main(string[] args)
            {
                Node head = null;
                LinkedList.Append(ref head, 25);
                LinkedList.Append(ref head, 5);
                LinkedList.Append(ref head, 18);
                LinkedList.Append(ref head, 7);
    
                Console.WriteLine("Linked list:");
                LinkedList.Print(head);
    
                Console.WriteLine();
                Console.WriteLine("Reversed Linked list:");
                LinkedList.Reverse(ref head);
                LinkedList.Print(head);
    
                Console.WriteLine();
                Console.WriteLine("Reverse of Reversed Linked list:");
                LinkedList.ReverseUsingRecursion(head);
                head = LinkedList.newHead;
                LinkedList.PrintRecursive(head);
            }
    
            public static class LinkedList
            {
                public static void Append(ref Node head, int data)
                {
                    if (head != null)
                    {
                        Node current = head;
                        while (current.Next != null)
                        {
                            current = current.Next;
                        }
    
                        current.Next = new Node();
                        current.Next.Data = data;
                    }
                    else
                    {
                        head = new Node();
                        head.Data = data;
                    }
                }
    
                public static void Print(Node head)
                {
                    if (head == null) return;
                    Node current = head;
                    do
                    {
                        Console.Write("{0} ", current.Data);
                        current = current.Next;
                    } while (current != null);
                }
    
                public static void PrintRecursive(Node head)
                {
                    if (head == null)
                    {
                        Console.WriteLine();
                        return;
                    }
                    Console.Write("{0} ", head.Data);
                    PrintRecursive(head.Next);
                }
    
                public static void Reverse(ref Node head)
                {
                    if (head == null) return;
                    Node prev = null, current = head, next = null;
                    while (current.Next != null)
                    {
                        next = current.Next;
                        current.Next = prev;
                        prev = current;
                        current = next;
                    }
                    current.Next = prev;
                    head = current;
                }
    
                public static Node newHead;
    
                public static void ReverseUsingRecursion(Node head)
                {
                    if (head == null) return;
                    if (head.Next == null)
                    {
                        newHead = head;
                        return;
                    }
    
                    ReverseUsingRecursion(head.Next);
                    head.Next.Next = head;
                    head.Next = null;
                }
            }
    
            public class Node
            {
                public int Data = 0;
                public Node Next = null;
            }
        }
    }
