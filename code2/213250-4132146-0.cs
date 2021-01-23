    public void Save(List<RetryAttempt> retryAttempts, TextWriter writer)
    {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<RetryAttempt>));
            xmlSerializer.Serialize(writer, retryAttempts);
        }
        catch (Exception ex)
        {
            LocalLogger.LogError("Unable to save retry information to xml file.", ex.ToString());
        }
    }
