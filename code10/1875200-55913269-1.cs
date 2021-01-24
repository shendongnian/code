    public static class Messenger
    {
        public static event Action<GameStateMessage> GameStateChanged;
        public static void OnGameStateChanged (GameStateMessage arg) => GameStateChanged?.Invoke(arg);
        public static event Action<Message> GameStarted;
        public static void OnGameStarted (Message arg) => GameStarted?.Invoke(arg);
    }
    Messenger.GameStarted += (Message arg) => // Subscribing to the event
    {
        Console.WriteLine(arg);
    };
    Messenger.OnGameStarted(new Message("Get ready!")); // Raising the event
