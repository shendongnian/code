    public List<RetryAttempt> GetRetryAttempts(TextReader reader)
    {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<RetryAttempt>));
            return (List<RetryAttempt>)xmlSerializer.Deserialize(reader);
        }
        catch (Exception ex)
        {
            LocalLogger.LogError("Unable to read from retry xml file.", ex.ToString());
        }
        return new List<RetryAttempt>();
    }
