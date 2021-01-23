    public void Config(Dictionary<String, String> values)
    {
        foreach(var kvp in values)
        {
            var configString = String.Format("{0}={1}", kvp.Key, kvp.Value);
            // do whatever
        }
    }
