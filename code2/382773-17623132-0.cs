    using System;
    namespace CSharpTestTemplates
    {
    class LinkedList
    {
        Node Head;
        public class Node
        {
            public int value;
            public Node NextNode;
            public Node(int value)
            {
                this.value = value;
            }
        }
        public LinkedList(Node head)
        {
            this.Head = head;
        }
        public Boolean hasLoop()
        {
            Node tempNode = Head;
            Node tempNode1 = Head.NextNode;
            while(tempNode!=null && tempNode1!=null){
                if(tempNode.Equals(tempNode1)){
                    return true;
                }
                if ((tempNode1.NextNode != null) && (tempNode.NextNode != null))
                {
                    tempNode1 = tempNode1.NextNode.NextNode;
                    tempNode = tempNode.NextNode;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public static void Main()
        {
            Node head = new Node(1);
            LinkedList ll = new LinkedList(head);
            
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);
            head.NextNode = node2;
            node2.NextNode = node3;
            node3.NextNode = node4;
            node4.NextNode = node5;
            node5.NextNode = node6;
            node6.NextNode = null;
            Console.WriteLine(ll.hasLoop());
            Console.Read();
        }
       }
     }
