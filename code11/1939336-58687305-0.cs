    I created in a namespace two clases:
    
    public partial class JsonModel
        {
            [JsonProperty("patient")]
            public Patient Patient { get; set; }
        }
    
        public partial class Patient
        {
    
            [JsonProperty("Number")]
            public string Number;
    
            [JsonProperty("FirstName")]
            public string FirstName;
    
            [JsonProperty("LastName")]
            public string LastName;
    
            [JsonProperty("BirthDate")]
            public DateTime BirthDate;
    
            [JsonProperty("Phone")]
            public string Phone;
    
            [JsonProperty("Mobile")]
            public string Mobile;
    
            [JsonProperty("Address")]
            public string Address;
    
            [JsonProperty("Job")]
            public string Job;
    
            [JsonProperty("Note")]
            public string Note;
    
            [JsonProperty("GenderId")]
            public int GenderId;
    
            // Return a textual representation of the order.
            public override string ToString()
            {
                return "FirstName: " + FirstName +
                "\nLastName: " + LastName +
                 "\nBirthDate: " + BirthDate
    
                ;
            }
        }
    
    created a console application for testing purpose:
    
    static void Main(string[] args)
            {
                string json = @"{
      ""patient"": {
     ""Number"": 20012,
     ""FirstName"":  ""Anas"",
     ""LastName"":  ""Tina"",
     ""BirthDate"": ""1986-12-29"",
     ""Phone"":  ""000000"",
     ""Mobile"":  ""00000"",
     ""Address"":  ""Damas"",
     ""Job"":  ""Developer"",
     ""Note"":  ""This is a note"",
     ""GenderId"": 1
      }
        } ";
    
                var test = FromJson(json);
                Console.WriteLine(test.Patient);
                Console.ReadKey();
            }
    
            public static JsonModel FromJson(string json)
            {
                // Return the result.enter code here
                return JsonConvert.DeserializeObject<JsonModel>(json);
            }
