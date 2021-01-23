    public sealed class ConsoleSurrogate {
        MessageQueue _mq = null;
        public override void Main(string[] args) {
            _mq = new MessageQueue(@".\private$\my_queue", QueueAccessMode.Receive);
            _mq.ReceiveCompleted += new ReceiveCompletedEventHandler(_mq_ReceiveCompleted);
            _mq.Formatter = new ActiveXMessageFormatter();
            MessagePropertyFilter filter = new MessagePropertyFilter();
            filter.Label = true;
            filter.Body = true;
            filter.AppSpecific = true;
            _mq.MessageReadPropertyFilter = filter;
            this.DoReceive();
            Console.ReadLine();
            _mq.Close();
        }
        void _mq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e) {
            _mq.EndReceive(e.AsyncResult);
            Console.WriteLine(e.Message.Body);
            this.DoReceive();
        }
        private void DoReceive() {
            _mq.BeginReceive();
        }
    }
