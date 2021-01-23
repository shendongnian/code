      namespace ConsoleApplication1
        {
           
        // T is the type of data stored in a particular instance of GenericList.
        public class GenericList<T>
        {
            private class Node
            {
                // Each node has a reference to the next node in the list.
                public Node Next;
                // Each node holds a value of type T.
                public T Data;
            }
    
            // The list is initially empty.
            private Node head = null;
    
            // Add a node at the beginning of the list with t as its data value.
            public void AddNode(T t)
            {
                Node newNode = new Node();
                newNode.Next = head;
                newNode.Data = t;
                head = newNode;
            }
    
            // The following method returns the data value stored in the last node in
            // the list. If the list is empty, the default value for type T is
            // returned.
            public T GetFirstAdded()
            {
                // The value of temp is returned as the value of the method. 
                // The following declaration initializes temp to the appropriate 
                // default value for type T. The default value is returned if the 
                // list is empty.
                T temp = default(T);
    
                Node current = head;
                while (current != null)
                {
                    temp = current.Data;
                    current = current.Next;
                }
                return temp;
            }
        }
    }
