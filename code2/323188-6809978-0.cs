            string[] emailsToSend = { "peter@test.com", "paul@test.com", "mary@test.com" };
     
            List<Task> tasks = new List<Task>();
            
            foreach (var email in emailsToSend)    {
                var e = email;
                tasks.Add(Task.Factory.StartNew(() => { Console.WriteLine("Sending Email to {0}", e); Thread.Sleep(5000); }));
            }
            Task.Factory.ContinueWhenAll(tasks.ToArray(), (_) => { Console.WriteLine("All Emails sent!"); });
            Console.ReadKey();
