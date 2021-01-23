        static void Main(string[] args)
        {
            AClass aClass = new AClass();
            aClass.MessageDelegate = ProcessMessage;
            // Send Message (writing of output unnecessary as it happens via the delegate anyway)
            Console.WriteLine(aClass.MessageSender(50));
            Console.ReadLine();
        }
        /// <summary>
        /// Used as delegate (messages passed from AClass to here)
        /// </summary>
        /// <param name="mess"></param>
        public static void ProcessMessage(String mess)
        {
            Console.WriteLine("Process message here: " + mess);
        }
        class AClass
        {
            public Action<string> MessageDelegate
            { get; set; }
            public AClass()
            {
            }
            public String MessageSender(int i)
            {
                InvokeMessage("Message: " + i);
                return "Message: " + i;
            }
            public void InvokeMessage(String mess)
            {
                if (MessageDelegate != null)
                {
                    MessageDelegate(mess);
                }                
            }
        }
