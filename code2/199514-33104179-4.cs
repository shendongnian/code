        using System;
        class Node<Type> : LinkedList<Type>
        {   // Why inherit from LinkedList? A: We need to use polymorphism.
            public Type value;
            public Node(Type value) { this.value = value; }
        }
        class LinkedList<Type>
        {   
            Node<Type> next;  // This member is treated as head in class LinkedList, but treated as next element in class Node.
            /// <summary> if x is in list, return previos pointer of x. (We can see any class variable as a pointer.)
            /// if not found, return the tail of the list. </summary>
            protected LinkedList<Type> Previos(Type x)
            {
                LinkedList<Type> p = this;      // point to head
                for (; p.next != null; p = p.next)
                    if (p.next.value.Equals(x))
                        return p;               // find x, return the previos pointer.
                return p;                       // not found, p is the tail.
            }
            /// <summary> return value: true = success ; false = x not exist </summary>
            public bool Contain(Type x) { return Previos(x).next != null ? true : false; }
            /// <summary> return value: true = success ; false = fail to add. Because x already exist. 
            /// </summary> // why return value? If caller want to know the result, they don't need to call Contain(x) before, the action waste time.
            public bool Add(Type x)
            {
                LinkedList<Type> p = Previos(x);
                if (p.next != null)             // Find x already in list
                    return false;
                p.next = new Node<Type>(x);
                return true;
            }
            /// <summary> return value: true = success ; false = x not exist </summary>
            public bool Delete(Type x)
            {
                LinkedList<Type> p = Previos(x);
                if (p.next == null)
                    return false;
                //Node<Type> node = p.next;
                p.next = p.next.next;
                //node.Dispose();       // GC dispose automatically.
                return true;
            }
            public void Print()
            {
                Console.Write("List: ");
                for (Node<Type> node = next; node != null; node = node.next)
                    Console.Write(node.value.ToString() + " ");
                Console.WriteLine();
            }
        }
        class Test
        {
            static void Main()
            {
                LinkedList<int> LL = new LinkedList<int>();
                if (!LL.Contain(0)) // Empty list
                    Console.WriteLine("0 is not exist.");
                LL.Print();
                LL.Add(0);      // Add to empty list
                LL.Add(1); LL.Add(2); // attach to tail
                LL.Add(2);      // duplicate add, 2 is tail.
                if (LL.Contain(0))// Find existed element which is head
                    Console.WriteLine("0 is exist.");
                LL.Print();
                LL.Delete(0);   // Delete head
                LL.Delete(2);   // Delete tail
                if (!LL.Delete(0)) // Delete non-exist element
                    Console.WriteLine("0 is not exist.");
                LL.Print();
                Console.ReadLine();
            }
        }
