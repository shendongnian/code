    class Program
    {
        static readonly object syncRoot = new object();
        private readonly static int maxParallelEmails  = 196;
    
        static void Main(string[] args)
        {
    
            IList<Model.SendEmailTo> recipients = _emailerService.GetEmailsToSend();
            int cnt = 0;
            int totalCnt = recipients.Count;
    
     
            Parallel.ForEach(recipients.AsParallel(), new ParallelOptions { MaxDegreeOfParallelism = maxParallelEmails }, recipient =>
            {
                // Do any other logic
    
                // Build the email HTML
    
                // Send the email, make sure to log exceptions
    
                // Track email, etc
    
                lock (syncRoot) cnt++;
                Console.WriteLine(String.Format("{0}/{1} - Sent newsletter email to: {2}", cnt, totalCnt, recipient.Email));
            });
        }
    }
