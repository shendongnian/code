    public static void ExecuteWithFailOver(Action toDo, string fileName)
    {
        for (var i = 1; i <= MaxAttempts; i++)
        {
            try
            {
                toDo();
                return;
            }
            catch (IOException ex)
            {
                Logger.Warn("File IO operation is failed. (File name: {0}, Reason: {1})", fileName, ex.Message);
                Logger.Warn("Repeat in {0} milliseconds.", i * 500);
                if (i < MaxAttempts)
                    Thread.Sleep(500 * i);
            }
        }
        throw new IOException(string.Format(CultureInfo.InvariantCulture,
                                            "Failed to process file. (File name: {0})",
                                            fileName));
    }
