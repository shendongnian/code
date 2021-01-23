        private static void SendEmailsUsingThreadPool(List<Recipient> recipients)
        {
          var coreCount = Environment.ProcessorCount;
          var itemCount = recipients.Count;
          var batchSize = itemCount / coreCount;
    
          var pending = coreCount;
          using (var mre = new ManualResetEvent(false))
          {
            for (int batchCount = 0; batchCount < coreCount; batchCount++)
            {
              var lower = batchCount * batchSize;
              var upper = (batchCount == coreCount - 1) ? itemCount : lower + batchSize;
              ThreadPool.QueueUserWorkItem(st =>
              {
                for (int i = lower; i < upper; i++)
                  SendEmail(recipients[i]);
                if (Interlocked.Decrement(ref pending) == 0)
                  mre.Set();
              });
            }
            mre.WaitOne();
          }      
        }
    
        private static void SendEmail(Recipient recipient)
        {
          //Send your Emails here
        }
      }
    
      class Recipient
      {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
      }
