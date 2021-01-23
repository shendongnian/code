    public class MessageProcessor
    {
        private Thread _ProcessingThread;
        private Queue<Message> _MessageQueue;
        private AutoResetEvent _MessagePosted;
        public MessageProcessor()
        {
            _MessagePosted = new AutoResetEvent(false);
            _MessageQueue = new Queue<Message>();
            _ProcessingThread = new Thread(ProcessMessages);
            _ProcessingThread.Start();
        }
        public void Post(Message msg)
        {
            _MessageQueue.Enqueue(msg);
            _MessagePosted.Set();
        }
        private void ProcessMessages(object state)
        {
            while (!_Quit)
            {
                _MessagePosted.WaitOne();
                _MessagePosted.WaitOne(TimeSpan.FromSeconds(5));
                ... process message queue
            }
        }
    }
