    public partial class FrmBooking : BookingManager.Core.BaseForm.BaseForm
    {
        public FrmBooking()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FrmBooking_FormClosing);
        }
        internal const string queName = @"messageServer\private$\Response";
        private Int32 counter = 0;
        private MessageQueue messageQueue = null;
        private bool formIsClosed = false;
        private void FrmBooking_Load(object sender, EventArgs e)
        {
            StartQueue();
        }
        void FrmBooking_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Set the flag to indicate the form is closed
            formIsClosed = true;
            // If the messagequeue exists, close it
            if (messageQueue != null)
            {
                messageQueue.Close();
            }
        }
        private void StartQueue()
        {
            if (MessageQueue.Exists(queName))
            {
                messageQueue = new MessageQueue(queName);
            }
            else
            {
                MessageQueue.Create(queName);
            }
            messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });
            // Add an event handler for the ReceiveCompleted event.
            messageQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(MessageReceived);
            messageQueue.BeginReceive(TimeSpan.FromSeconds(15));
        }
        // Provides an event handler for the ReceiveCompleted event.
        private void MessageReceived(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            if (!this.formIsClosed)
            {
                // End the asynchronous receive operation.
                System.Messaging.Message msg = messageQueue.EndReceive(asyncResult.AsyncResult);
                // Display the message information on the screen.
                listBoxControl1.Items.Add(msg.Body.ToString());
                counter++;
                labelControl1.Text = String.Format("Total messages received {0}", counter.ToString());
                // Start receiving the next message
                messageQueue.BeginReceive(TimeSpan.FromSeconds(15));
            }
        }
    }
