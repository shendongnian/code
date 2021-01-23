    private static IList<string> GetLatestCommitMessages(Uri repository, int count)
    {
        using (var client = new SvnClient())
        {
            System.Collections.ObjectModel.Collection<SvnLogEventArgs> logEntries;
            var args = new SvnLogArgs()
            {
                Limit = count
            };
    
            client.GetLog(repository, args, out logEntries);
    
            return logEntries.Select(log => log.LogMessage).ToList();
        }
    }
