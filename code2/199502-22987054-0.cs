    public class DynamicLinkedList
    {
        private class Node
        {
            private object element;
            private Node next;
            public object Element
            {
                get { return this.element; }
                set { this.element = value; }
            }
            public Node Next
            {
                get { return this.next; }
                set { this.next = value; }
            }
            public Node(object element, Node prevNode)
            {
                this.element = element;
                prevNode.next = this;
            }
            public Node(object element)
            {
                this.element = element;
                next = null;
            }
        }
        private Node head;
        private Node tail;
        private int count;
        public DynamicLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
        public void AddAtLastPosition(object element)
        {
            if (head == null)
            {
                head = new Node(element);
                tail = head;
            }
            else
            {
                Node newNode = new Node(element, tail);
                tail = newNode;
            }
            count++;
        }
        public object GetLastElement()
        {
            object lastElement = null;
            Node currentNode = head;
            while (currentNode != null)
            {
                lastElement = currentNode.Element;
                currentNode = currentNode.Next;
            }
            return lastElement;
        }
    }
