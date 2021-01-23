    static void Main(string[] args)
        {
            if (!MessageQueue.Exists(@"ComputerName\private$\SomeQueue"))
                MessageQueue.Create(@"ComputerName\private$\SomeQueue");
            else
            {
                using (MessageQueue x = new MessageQueue(@"ComputerName\private$\SomeQueue"))
                {
                    if (x.CanRead)
                        x.Receive();
                }
            }
        }
