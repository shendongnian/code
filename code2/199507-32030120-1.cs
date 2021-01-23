    public class Node
    {
        public Node next;
        public object data;
    }
    public class MyLinkedList
    {
         Node head;
         public Node AddNodes(Object data)
         {
             Node node = new Node();
             if (node.next == null)
             {
                 node.data = data;
                 node.next = head;
                 head = node;
             }
             else
             {
                 while (node.next != null)
                     node = node.next;
                 node.data = data;
                 node.next = null;
             }
             return node;
         }
         public void printnodes()
         {
             Node current = head;
             while (current.next != null)
             {
                 Console.WriteLine(current.data);
                 current = current.next;
             }
             Console.WriteLine(current.data);
         }
    }
    [TestClass]
    public class LinkedListExample
    {
        MyLinkedList linkedlist= new MyLinkedList();
        [TestMethod]
        public void linkedlisttest()
        {
            linkedlist.AddNodes("hello");
            linkedlist.AddNodes("world");
            linkedlist.AddNodes("now");
            linkedlist.printnodes();
        }
    }
}
