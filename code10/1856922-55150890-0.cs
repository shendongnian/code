    public class Property
        {
          public string property { get; set; }
          public string value { get; set; }
        }
    
        public class Customer
        {
          public string email { get; set; }
          public List<Property> properties { get; set; }
    
        }
    
        static void Main(string[] args)
        {
          string JSON = @"[
       {""email"":""test @test.com"",
          ""properties"":[
          {
            ""property"":""company"",
            ""value"": ""Company Name""
          },
           { ""property"":""firstname"",
            ""value"":""John""
          },
           { ""property"":""surname"",
             ""value"":""Smith""
          },
           { ""property"":""phone"",
            ""value"":""01234567891""
          }]
      }
    ]
    ";
          Customer[] obj = JsonConvert.DeserializeObject<Customer[]>(JSON);
    
        }
