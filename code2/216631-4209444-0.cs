    public class Something
    {
        private Queue<Action> actionQueue = new Queue<Action>();
        private volatile bool threadRunning = true;
        public void RunOnThread(Action action)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            lock (actionQueue)
                actionQueue.Enqueue(action);
        }
        public void Stop()
        {
            threadRunning = false;
        }
        private void RunPendingActions()
        {
            while (actionQueue.Count > 0) {
                Action action;
                lock (actionQueue)
                    action = actionQueue.Dequeue();
                action();
            }
        }
        public void MainThreadLoop()
        {
            while (threadRunning) {
                // Do the stuff you were already doing on this thread.
                // Then, periodically...
                RunPendingActions();
            }
        }
    }
