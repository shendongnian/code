    public class Handler
    {
        private readonly BlockingCollection<QueueEntry> _queue = new BlockingCollection<QueueEntry>();
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        // I used a Form with a button to simulate events, so you'll have to adapt that..
        public Handler(Form1 parent)
        {
            // register for incoming Items
            parent.NewItems += Parent_NewItems;
            // Start processing on a long running Pool-Thread
            Task.Factory.StartNew(QueueWorker, TaskCreationOptions.LongRunning);
        }
        // Stop Processing
        public void Shutdown( bool doitnow )
        {
            // Mark the queue "complete" - adding is now forbidden.
            _queue.CompleteAdding();
            // If you want to stop NOW, cancel all operations
            if (doitnow ) { _cts.Cancel(); }
            // Else the Task will run until the queue has been processed.
        }
        // This is all that happens on the EDT / Main / UI Thread
        private void Parent_NewItems(object sender, NewItemsEventArgs e)
        {
            try
            {
                _queue.Add(new QueueEntry { Sender = sender, Event = e });
            }
            catch (InvalidOperationException)
            {
                // dontcare ? I didn't - You may, though.
                // Will be thrown if the queue has been marked complete.
            }
        }
        private async Task QueueWorker()
        {
            // While the queue has not been marked complete and is empty
            while (!_queue.IsCompleted)
            {
                QueueEntry entry = null;
                try
                {
                    // Wait until an entry is available or until canceled.
                    entry = _queue.Take(_cts.Token); 
                }
                catch ( OperationCanceledException )
                {
                    // dontcare
                }
                if (entry != null)
                {
                    await Process(entry, _cts.Token);
                }
            }
        }
        private async Task Process(QueueEntry entry, CancellationToken cancel)
        {
            // Dummy Processing...
            await Task.Delay(TimeSpan.FromSeconds(entry.Event.Items), cancel);
        }
    }
    public class QueueEntry
    {
        public object Sender { get; set; }
        public NewItemsEventArgs Event { get; set; }
    } 
