        public class NetworkPublishingTraceListener : TraceListener {
        private List<string> messages = new List<string>();
        private AutoResetEvent messagesAvailable = new AutoResetEvent(false);
        private List<TcpClient> traceViewerApps;
        private object messageQueueLock = new object();
        public NetworkPublishingTraceListener(int port) {
            // Setup code for accepting and dealing with network connections. 
            (new Thread(BackgroundThread) { IsBackground = true }).Start();
        }
        
        public override void Write(string message) {
            if (traceViewerApps.Count == 0) {
                return;
            }
            lock (messageQueueLock) {
                messages.Add(message);               
            }
            messagesAvailable.Set();
        }
        public override void WriteLine(string message) {
            Write(message + Environment.NewLine);
        }
        private void BackgroundThread() {
            while (true) {
                messagesAvailable.WaitOne();
                List<string> messagesToWrite;
                lock (messageQueueLock) {
                    messagesToWrite = messages;
                    messages = new List<string>();
                }
                traceViewerApps.ForEach(viewerApp => {
                    StreamWriter writer = new StreamWriter(viewerApp.GetStream());
                    messagesToWrite.ForEach(message => writer.Write(message));
                });
            }
        }
    }
