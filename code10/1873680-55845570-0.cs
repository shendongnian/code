    class Printer
    {
        MessageOrigin mo = new MessageOrigin();
        public Printer()
        {
            mo.NewMessage += PrintMessage; // Subscribe to the event
        }
        void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
    class MessageOrigin
    {
        public event Action<string> NewMessage; // Declare the event
        public void GetMessage()
        {
            string msgs = Get_All_Message();
            NewMessage?.Invoke(msgs); // Raise the event
        }
    }
