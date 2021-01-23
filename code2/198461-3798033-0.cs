    public class BlockingQueue<T> {
        private Queue<T> queue = new Queue<T>();
    
        public void Enqueue(T obj) {
            lock (queue) {
                queue.Enqueue(obj);
                Monitor.Pulse(queue);
            }
        }
    
        public T Dequeue() {
            T obj;
            lock (queue) {
                while (queue.Count == 0) {
                    Monitor.Wait(queue);
                }
                obj = queue.Dequeue();
            }
            return obj;
        }
    }
