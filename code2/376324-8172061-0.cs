    public static class LevelMessengerManager
    {
        public static void MarkAsPermanent(string eventType,
            Callback<LevelInfo, GameDataType> messageHandler)
        {
            MessengerManager.MarkAsPermanent(eventType, messageHandler);
        }
    }
