    class MyStack<T>
    {
        LinkedList<T> linkedList = new LinkedList<T>();
    
        public void Push(T t)
        {
            linkedList.AddFirst(t);
        }
    
        public T Pop()
        {
            T result = linkedList.First.Value;
            linkedList.RemoveFirst();
            return result;
        }
    }
