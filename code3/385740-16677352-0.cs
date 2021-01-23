    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace LCA
    {
        class Node
        {
            public Node(int data, Node a, Node b)
            {
                IData = data;
                LeftChild = a;
                RightChild = b;
            }
    
            public int IData { get; set; }
            public Node RightChild { get; set; }
            public Node LeftChild { get; set; }
        }
    
        class Program
        {
            static Node a = new Node(10, null, null);
            static Node b = new Node(14, null, null);
            static Node ab = new Node(12, a, b);
            static Node c = new Node(4, null, null);
            static Node ac = new Node(8, c, ab);
            static Node d = new Node(22, null, null);
            static Node root = new Node(20, ac, d);
    
            static void Main(string[] args)
            {
                string line;
                line = Console.ReadLine();
                string[] ip = line.Split(' ');
                int ip1 = -1;
                int ip2 = -1;
    
                if (ip.Length == 2)
                {
                    Int32.TryParse(ip[0], out ip1);
                    Int32.TryParse(ip[1], out ip2);
                    int i = -1;
                    Node node = null;
                    Node node1 = new Node(ip1, null, null);
                    Node node2 = new Node(ip2, null, null);
                    if (contains(root, node1))
                    {
                        if (!contains(root, node2))
                            node = node1;
                    }
                    else
                    {
                        if (!contains(root, node2))
                            node = new Node(-1, null, null);
                        else
                            node = node2;
                    }
                    if (node == null)
                        node = LCA(root, node1, node2);
    
                    Int32.TryParse(node.IData.ToString(), out i);
    
                    Console.WriteLine(i);
                    Console.ReadLine();
                }
            }
    
            public static Node LCA(Node root, Node a, Node b)
            {
                if (root == null) return null;
    
                Node small, large, current = root;
                if (a.IData < b.IData)
                {
                    small = a;
                    large = b;
                }
                else
                {
                    small = b;
                    large = a;
                }
                if (large.IData < current.IData)
                {
                    do
                    {
                        current = current.LeftChild;
                    } while (current != null && large.IData < current.IData);
                    if (current == null) return null;
                    if (current.IData < small.IData) return LCA(current, small, large);
                    // if we get here, current has the same IData as one of the two, the two are
                    // in different subtrees, or not both are in the tree
                    if (contains(current, small) && contains(current, large)) return current;
                    // at least one isn't in the tree, return null
                    return null;
                }
                else if (current.IData < small.IData)
                {
                    do
                    {
                        current = current.RightChild;
                    } while (current != null && current.IData < small.IData);
                    if (current == null) return null;
                    if (current.IData < small.IData) return LCA(current, small, large);
                    // if we get here, current has the same IData as one of the two, the two are
                    // in different subtrees, or not both are in the tree
                    if (contains(current, small) && contains(current, large)) return current;
                    // at least one isn't in the tree, return null
                    return null;
                }
                else // Not both in the same subtree
                {
                    if (contains(current, small) && contains(current, large)) return current;
                }
                return null; // at least one not in tree
            }
    
            public static bool contains(Node root, Node target)
            {
                if (root == null) return false;
                if (root.IData == target.IData) return true;
                if (root.IData < target.IData) return contains(root.RightChild, target);
                return contains(root.LeftChild, target);
            }
        }
    }
