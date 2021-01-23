        using System.Threading;
        
        Task<string>[] tasks = new[]
        {
          Task<string>.Factory.StartNew( () => new System.Net.WebClient().DownloadString(@"http://icanhazip.com").Trim() ),
          Task<string>.Factory.StartNew( () => new System.Net.WebClient().DownloadString(@"http://checkip.dyndns.org").Trim() )
        };
        int index = Task.WaitAny( tasks );
        string ip = tasks[index].Result;
