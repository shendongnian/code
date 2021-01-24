    public class Player : IDisposable
    {
        public Player() // Constructor
        {
            Messenger.GameStarted += Messenger_GameStarted; // Subscribe
        }
        private void Messenger_GameStarted(Message arg) // Event handler
        {
            Console.WriteLine(arg);
        }
        public void Dispose() // This method must be called when the object is about to perish
        {
            Messenger.GameStarted -= Messenger_GameStarted; // Unsubscribe
        }
    }
