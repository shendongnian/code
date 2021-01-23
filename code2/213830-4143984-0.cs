    public class MailSystem
    {
        private readonly Queue<Mail> mailQueue = new Queue<Mail>();
        private bool running;
        private Thread consumerThread;
        public static void Main(string[] args)
        {
            MailSystem mailSystem = new MailSystem();
            mailSystem.StartSystem();
        }
        public void StartSystem()
        {
            // init consumer
            running = true;
            consumerThread = new Thread(ProcessMails);
            consumerThread.Start();
            // add some mails
            mailQueue.Enqueue(new Mail("Mail 1"));
            mailQueue.Enqueue(new Mail("Mail 2"));
            mailQueue.Enqueue(new Mail("Mail 3"));
            mailQueue.Enqueue(new Mail("Mail 4"));
            Console.WriteLine("producer finished, hit enter to stop consumer");
            // wait for user interaction
            Console.ReadLine();
            // exit the consumer
            running = false;
            Console.WriteLine("exited");
        }
        private void ProcessMails()
        {
            while (running)
            {
                if (mailQueue.Count > 0)
                {
                    Mail mail = mailQueue.Dequeue();
                    Console.WriteLine(mail.Text);
                    Thread.Sleep(2000);
                }
            }
        }
    }
    internal class Mail
    {
        public string Text { get; set; }
        public Mail(string text)
        {
            Text = text;
        }
    }
