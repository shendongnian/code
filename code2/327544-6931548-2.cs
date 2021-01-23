    public class Generic<T> where T : class
    {
        private class Node<U>
        {
            public U data; // U can be anything
        }
    
        private Node<T> myNode;  // U will be of type T
    }
