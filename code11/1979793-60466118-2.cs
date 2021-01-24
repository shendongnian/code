    using Newtonsoft.Json;
    using System.Collections.Generic;
    ...
    string json = @"[
      {
        ""starttime"": ""2020 - 02 - 27T14: 30:00Z"",
        ""endtime"": ""2020-02-27T14:40:00Z""
      },
      {
        ""Temp"": {
          ""value"": 3
        },
        ""Pressure"": {
          ""value"": 29
        },
        ""Humidity"": {
          ""value"": 85
        }
      }
    ]";
    var myObject = JsonConvert.DeserializeObject<List<Class1>>(json);
