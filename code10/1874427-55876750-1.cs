    private static readonly httpClient = new HttpClient();
    public async Task<IEnumerable<string>> GetAPIResults(IEnuemrable<MatchList> matchLists,
      int maximumRequestsPerSecond)
    {
        var requests = matchLists
          .Select(ml => new RequestStatus { MatchList = ml })
          .ToList();
        foreach (var request in requests)
        {
          var activeRequests = RequestStatus
            .Where(rs => 
              (rs.RequestedOn.HasValue && rs.RequestedOn > DateTime.Now.AddSeconds(-1))
              || (rs.Task.HasValue && rs.Task.TaskStatus != TaskStatus.Running))
            .ToList();
          //wait for either a request to complete
          //or for a request not active within the last second to expire
          while (activeRequests > maximumRequestsPerSecond)
          {
            var lastActive = activeRequests.OrderBy(RequestedOn.Value).First();
            var waitFor = DateTime.Now - lastActive.RequestedOn.Value;
            // or maybe this to be safe
            // var waitFor = (DateTime.Now - lastActive.RequestedOn.Value)
            //   .Add(TimeSpan.FromMilliseconds(100));
            await Task.Delay(waitFor);
            activeRequests = RequestStatus
              .Where(rs => 
                (rs.RequestedOn.HasValue && rs.RequestedOn > DateTime.Now.AddSeconds(-1))
                || (rs.Task.HasValue && rs.Task.TaskStatus != TaskStatus.Running))
              .ToList();
        }
          request.RequestTask = httpClient.GetStringAsync(myUrl);       
        }
        await Task.WhenAll(requests.Select(r => r.RequestTask.Value));
        // not sure about .Result here...
        return requests.Select(r => r.RequestTask.Value.Result).ToList();
        // probably safer:
        return requests.Select(r => await r.RequestTask).ToList();
    }
    public class RequestStatus
    {
      public MatchList MatchList { get; set; }
      public DateTime? RequestedOn { get; set }
      public Task<string>? RequestTask { get; set; }
    }
