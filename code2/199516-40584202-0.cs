     using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        
        namespace SingleLinkedList
        {
            class Program
            {
                Node head;
                Node current;
                int counter = 0;
                public Program()
                {
                    head = new Node();
                    current = head;
                }
                public void AddStart(object data)
                {
                    Node newnode = new Node();
                    newnode.next = head.next;
                    newnode.data = data;
                    head.next = newnode;
                    counter++;
                }
                public void AddEnd(object data)
                {
                    Node newnode = new Node();
                    newnode.data = data;
                    current.next = newnode;
                    current = newnode;
                    counter++;
                }
                public void RemoveStart()
                {
                    if (counter > 0)
                    {
                        head.next = head.next.next;
                        counter--;
                    }
                    else
                    {
                        Console.WriteLine("No element exist in this linked list.");
                    }
                }
                public void RemoveEnd()
                {
                    if (counter > 0)
                    {
                        Node prevNode = new Node();
                        Node cur = head;
                        while (cur.next != null)
                        {
                            prevNode = cur;
                            cur = cur.next;
                        }
                        prevNode.next = null;
                    }
                    else
                    {
                        Console.WriteLine("No element exist in this linked list.");
                    }
                }
                public void Display()
                {
                    Console.Write("Head ->");
                    Node curr = head;
                    while (curr.next != null)
                    {
                        curr = curr.next;
                        Console.WriteLine(curr.data.ToString());
                    }
                }
                public class Node
                {
                    public object data;
                    public Node next;
                }
                static void Main(string[] args)
                {
                    Program p = new Program();
                    p.AddEnd(2);
                    p.AddStart(1);
                    p.AddStart(0);
                    p.AddEnd(3);
                    p.Display();
                    p.RemoveStart();
                    Console.WriteLine("Removed node from Start");
                    p.Display();
                    Console.WriteLine("Removed node from End");
                    p.RemoveEnd();
                    p.Display();
                    Console.ReadKey();
                }
            }
        }
