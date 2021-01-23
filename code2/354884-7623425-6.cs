    class LinkedList<T> : IEnumerable<T> where T: IComparable
    {
        public Node<T> Head {set;get;}
        public Node<T> Tail {set;get;}
        
        // set of constructors
        //.....
        public void Insert(Node<T> node)
        {
           // you can do recursive or iterative impl. very easy.
        }
     
        // other public methods such as remove, insertAfter, insert before, insert last etc.
        public void Sort()
        {
           // easiest solution is to use insertion sort based on priority.
        }
    
    }
