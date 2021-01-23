    public class Node<T>
    {
        public T item;
        public Node<T> next;
        public Node()
        {
            this.next = null;
        }
    }
    class LinkList<T>
    {
        public Node<T> head { get; set; }
        public LinkList()
        {
            this.head = null;
        }
        public void AddAtHead(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.item = item;
            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                newNode.next = head;
                this.head = newNode;
            }
        }
        public void AddAtTail(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.item = item;
            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                Node<T> temp = this.head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newNode;
            }
        }
        public void DeleteNode(T item)
        {
            if (this.head.item.Equals(item))
            {
                head = head.next;
            }
            else
            {
                Node<T> temp = head;
                Node<T> tempPre = head;
                bool matched = false;
                while (!(matched = temp.item.Equals(item)) && temp.next != null)
                {
                    tempPre = temp;
                    temp = temp.next;
                }
                if (matched)
                {
                    tempPre.next = temp.next;
                }
                else
                {
                    Console.WriteLine("Value not found!");
                }
            }
        }
        public bool searchNode(T item)
        {
            Node<T> temp = this.head;
            bool matched = false;
            while (!(matched = temp.item.Equals(item)) && temp.next != null)
            {
                temp = temp.next;
            }
            return matched;
        }
        public void DisplayList()
        {
            Console.WriteLine("Displaying List!");
            Node<T> temp = this.head;
            while (temp != null)
            {
                Console.WriteLine(temp.item);
                temp = temp.next;
            }
        }
    }
