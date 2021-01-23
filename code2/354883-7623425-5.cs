    class Node<T> : IComparable<T>
    {
       public int Priority {set;get;}
       public T Data {set;get;}
       public Node<T> Next {set;get;}
       public Node<T> Previous {set;get;}
       // you need to implement IComparable here for sorting.
    }
