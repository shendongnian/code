    static void Main(string[] args)
        {            
            // create class passing in delegate for processing
            AClass aClass = new AClass(ProcessMessage);
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
            // local delegate instance
            private Action<string> _messageDelegate;
            /// <summary>
            /// Require delegate on class instantiation (could be a property if required)
            /// </summary>
            /// <param name="messageDelegater"></param>
            public AClass(Action<string> messageDelegater)
            {
                _messageDelegate = messageDelegater;
            }
            public String MessageSender(int i)
            {
                InvokeMessage("Message: " + i);
                return "Message: " + i;
            }
            public void InvokeMessage(String mess)
            {
                _messageDelegate(mess);
            }
        }
