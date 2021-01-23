    public class Generic<T> where T : class
    {
        private class Node
        {
            public T data; // T will be of the type use to construct Generic<T>
        }
    
        private Node myNode;  // No need for Node<T>
    }
