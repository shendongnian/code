    private IEnumerable<string> ReadEmailLogLines(string EmailLog)
    {
        using(StreamReader logreader = new StreamReader(EmailLog))
        {
            string line = logreader.ReadLine();
            while(line != null)
            {
                 yield return line;
            }
        }
    }
