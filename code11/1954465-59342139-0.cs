      public class Response
      {
          public string Domain { get; set; }
          public Data Data { get; set; }
      }
      var response = JsonConvert.DeserializeObject<Response>(finishResponse);
      Console.WriteLine(response.Data.available);
