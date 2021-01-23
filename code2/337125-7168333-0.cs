    public void Log(string message, LogType type)
    {
        // Note use of property
        Activity = Activity + "\n" + type.ToString() + ": " + message;
    }
