    public class QueueWrapper<T>
    {
         private Queue<T> _queue;
         public void Enqueue(T item)
         {
             if (_queue.Count > 5)
                 throw new Exception();
        
             if(this.Contains(item))
                 throw new Exception();
             
             _queue.Enqueue(item);
         }
    
         //Any other methods you might want to use would also need to be exposed similarly
    }
