    public class FixedSizedQueue<T> {
          private object LOCK = new object();
          ConcurrentQueue<T> queue;
    
          public int Limit { get; set; }
    
          public FixedSizedQueue(int limit, IEnumerable<T> items = null) {
             this.Limit = limit;
             if (items == null) {
                queue = new ConcurrentQueue<T>();
             }
             else {
                queue = new ConcurrentQueue<T>(items);
                EnsureLimitConstraint();
             }
          }
    
          public void Enqueue(T obj) {
             queue.Enqueue(obj);
             EnsureLimitConstraint();
          }
    
          private void EnsureLimitConstraint() {
             if (queue.Count > Limit) {
                lock (LOCK) {
                   T overflow;
                   while (queue.Count > Limit) {
                      queue.TryDequeue(out overflow);
                   }
                }
             }
          }
    
    
          /// <summary>
          /// returns the current snapshot of the queue
          /// </summary>
          /// <returns></returns>
          public T[] GetSnapshot() {
             return queue.ToArray();
          }
       }
