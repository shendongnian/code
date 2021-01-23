    class Program
        {
            static void Main(string[] args)
            {
                Listener listener = new Listener();
                Sender sender = new Sender();
                sender.Send = new TalkDelegate(listener.TalkToMe);
                Thread thread = new Thread(sender.Run);
                thread.IsBackground = true;
                thread.Start();
                listener.Listen();
            }
        }
    
        delegate bool TalkDelegate(string messageArg);
    
        class Listener
        {
            bool keepListening = true;
    
            public bool TalkToMe(string messageArg)
            {
                Console.WriteLine(messageArg);
                return keepListening;
            }
    
            public void Listen()
            {
                DateTime startTime = DateTime.Now;
                while ((DateTime.Now - startTime) < TimeSpan.FromSeconds(10))
                {
                    Thread.Sleep(100);
                }
                keepListening = false;
            }
        }
    
        class Sender
        {
            public TalkDelegate Send;
    
            public void Run()
            {
                bool keepTalking = true;
                while (keepTalking)
                {
                    keepTalking = Send(DateTime.Now.ToString("HH:mm:ss"));
                    Thread.Sleep(1000);
                }
            }
        }
