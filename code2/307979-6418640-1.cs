    public static class QueueExtensions {
        public static int DequeueInt(this Queue<string> queue) {
            return Convert.ToInt32(queue.Dequeue());
        }
    }
    ProcessPerson(queue.DequeueInt(), queue.Dequeue());
