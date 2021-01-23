    using System.Collections.Generic;
    public static class Q_Example
    {
        private readonly Queue<int> q = new Queue<int>();
        public void Method1(int val)
        {
            lock(q.SyncRoot)
            {
                q.EnQueue(val);
            }
        }
        public int Method2()
        {
            lock(q.SyncRoot)
            {
                return q.Dequeue();
            }
        }
    }
