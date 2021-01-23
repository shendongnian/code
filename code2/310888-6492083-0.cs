    namespace MessageService 
{ 
    public partial class MessageService : ServiceBase 
    { 
        public MessageService() 
        { 
            InitializeComponent(); 
        } 
 
        private string MessageDirectory = ConfigurationManager.AppSettings["MessageDirectory"]; 
        private string MessageQueue = ConfigurationManager.AppSettings["MessageQueue"]; 
        
        private System.Messaging.MessageQueue messageQueue = null; 
        
        private ManualResetEvent manualResetEvent = new ManualResetEvent(true); 
        
        
        protected override void OnStart(string[] args) 
        { 
            // Create directories if needed 
            if (!System.IO.Directory.Exists(MessageDirectory)) 
                System.IO.Directory.CreateDirectory(MessageDirectory); 
            
            // Create new message queue instance 
            messageQueue = new System.Messaging.MessageQueue(MessageQueue); 
 
            try 
            {    
                // Set formatter to allow ASCII text 
                messageQueue.Formatter = new System.Messaging.ActiveXMessageFormatter(); 
                // Assign event handler when message is received 
                messageQueue.ReceiveCompleted += 
                    new System.Messaging.ReceiveCompletedEventHandler(messageQueue_ReceiveCompleted); 
                // Start listening 
                
                messageQueue.BeginReceive(); 
            } 
            catch (Exception e) 
            { 
                
            } 
        } 
 
        protected override void OnStop() 
        { 
            //Make process synchronous before closing the queue 
            manualResetEvent.WaitOne(); 
 
            
            // Clean up 
            if (this.messageQueue != null) 
            { 
                this.messageQueue.Close(); 
                this.messageQueue = null; 
            } 
        } 
        
        public void messageQueue_ReceiveCompleted(object sender, System.Messaging.ReceiveCompletedEventArgs e) 
        { 
            manualResetEvent.Reset(); 
            System.Messaging.Message completeMessage = null; 
            System.IO.FileStream fileStream = null; 
            System.IO.StreamWriter streamWriter = null; 
            string fileName = null; 
            
