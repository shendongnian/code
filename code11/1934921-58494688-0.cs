    public class GroupChatForm : Form
    {
        public void foo()
        {
            GroupChat gc = new GroupChat();
            gc.MessageReceived += Gc_MessageReceived; // wire up the event
            gc.Start();
        }
        private void Gc_MessageReceived(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    Gc_MessageReceived(message); // recursive call that will become UI safe on the second call
                }));
            }
            else
            {
                // ... it's safe to update your GUI in here with "message" ...
            }
        }
    }
    public class GroupChat
    {
        public delegate void dlgMessage(String message);
        public event dlgMessage MessageReceived;
        public void Start()
        {
            // setup your TCP stuff
            // start a new thread that has MessageLoop() below in it
        }
        public void MessageLoop() // ... running in a new THREAD ...
        {
            String message;
            bool newMessageReceived = false;
            while (true)
            {
                // ... blocking code that receives a message ...
                message = "some message from the stream";
                newMessageReceived = true;
                if (newMessageReceived)
                {
                    // raise the event w/ the message
                    MessageReceived?.Invoke(message);
                    newMessageReceived = false;
                }
            }
        }
    }
