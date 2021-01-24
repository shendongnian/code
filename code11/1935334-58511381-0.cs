     public class ListRecev
        {
            public string href { get; set; }
            
        }
      var resultjson = JsonConvert.DeserializeObject<ListRecev>(result);
      foreach (var backgroundTaskURL in resultjson)
      {
       filaUPloads.Add(backgroundTaskURL.href);
      }
