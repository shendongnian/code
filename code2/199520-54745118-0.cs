AddFirst(data), AddFirst(node), AddLast(data), RemoveLast(), AddAfter(node, data), RemoveBefore(node), Find(node), Remove(foundNode), Print(LinkedList)
    
    using System;
    using System.Collections.Generic;
    
    namespace Codebase
    {
        public class Node
        {
            public object Data { get; set; }
            public Node Next { get; set; }
    
            public Node()
            {
            }
    
            public Node(object Data, Node Next = null)
            {
                this.Data = Data;
                this.Next = Next;
            }
        }
    
        public class LinkedList
        {
            private Node Head;
            public Node First
            {
                get => Head;
                set
                {
                    First.Data = value.Data;
                    First.Next = value.Next;
                }
            }
    
            public Node Last
            {
                get
                {
                    Node p = Head;
                    //Based partially on https://en.wikipedia.org/wiki/Linked_list
                    while (p.Next != null)
                        p = p.Next; //traverse the list until p is the last node.The last node always points to NULL.
    
                    return p;
                }
                set
                {
                    Last.Data = value.Data;
                    Last.Next = value.Next;
                }
            }
    
            public void AddFirst(Object data, bool verbose = true)
            {
                Head = new Node(data, Head);
                if (verbose) Print();
            }
    
            public void AddFirst(Node node, bool verbose = true)
            {
                node.Next = Head;
                Head = node;
                if (verbose) Print();
            }
    
            public void AddLast(Object data, bool Verbose = true)
            {
                Last.Next = new Node(data);
                if (Verbose) Print();
            }
    
            public Node RemoveFirst(bool verbose = true)
            {
                Node temp = First;
                Head = First.Next;
                if (verbose) Print();
                return temp;
            }
    
            public Node RemoveLast(bool verbose = true)
            {
                Node p = Head;
                Node temp = Last;
    
                while (p.Next != temp)
                    p = p.Next;
    
                p.Next = null;
                if (verbose) Print();
    
                return temp;
            }
    
            public void AddAfter(Node node, object data, bool verbose = true)
            {
                Node temp = new Node(data);
                temp.Next = node.Next;
                node.Next = temp;
    
                if (verbose) Print();
            }
    
            public void AddBefore(Node node, object data, bool verbose = true)
            {
                Node temp = new Node(data);
    
                Node p = Head;
    
                while (p.Next != node) //Finding the node before
                {
                    p = p.Next;
                }
    
                temp.Next = p.Next; //same as  = node
                p.Next = temp;
    
                if (verbose) Print();
            }
    
            public Node Find(object data)
            {
                Node p = Head;
    
                while (p != null)
                {
                    if (p.Data == data)
                        return p;
    
                    p = p.Next;
                }
                return null;
            }
    
            public void Remove(Node node, bool verbose = true)
            {
                Node p = Head;
    
                while (p.Next != node)
                {
                    p = p.Next;
                }
    
                p.Next = node.Next;
                if (verbose) Print();
            }
    
            public void Print()
            {
                Node p = Head;
                while (p != null) //LinkedList iterator
                {
                    Console.Write(p.Data + " ");
                    p = p.Next; //traverse the list until p is the last node.The last node always points to NULL.
                }
                Console.WriteLine();
            }
        }
    }
