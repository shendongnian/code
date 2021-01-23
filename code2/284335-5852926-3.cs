     public class FixedSizedQueue<T>
     {
         ConcurrentQueue<T> q = new ConcurrentQueue<T>();
         public int Limit { get; set; }
         public void Enqueue(T obj)
         {
            q.Enqueue(obj);
            lock (this)
            {
               T overflow;
               while (q.Count > Limit) q.TryDequeue( out overflow );
            }
         }
     }
