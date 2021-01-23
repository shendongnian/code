        private MessageQueue messageQueue;
        public const string DEFAULT_QUEUE_NAME = "newQueue";
        public const string QUEUENAME_PREFIX = ".\\Private$\\";
        public static string QueueName
        {
            get
            {
                string result = string.Format("{0}{1}", QUEUENAME_PREFIX, DEFAULT_QUEUE_NAME);
                return result;
            }
        }
       public void SendMessage()
        {
            string queuePath = QueueName;
            MessageQueue  messageQueue = MessageQueue.Create(queuePath);
            messageQueue.Send("msg");            
        }
