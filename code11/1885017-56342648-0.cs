    public Form1()
            {
                InitializeComponent();
    
                try
                {
    
                var json = @"{
                              'extension_7182f7a071344106a9e47cc960ab93e8_DOB': '17/12/1995',
                              'extension_7182f7a071344106a9e47cc960ab93e8_middleName': 'Roger',
                              'objectID': '',
                              'accountEnabled': true,
                              'email': 'Test'
                             }";
                
                    var items = JsonConvert.DeserializeObject<ResponseModelPrime>(json);
    
                }
                catch (Exception ex)
                {
                    var exception = ex;
                }
            }
            public class ResponseModelPrime
            {           
                [JsonProperty(PropertyName = "odata.metadata")]
                public string OdataMetadata { get; set; }
             
                [JsonProperty(PropertyName = "objectId")]
                public string ObjectId { get; set; }
    
                [JsonProperty(PropertyName = "email")]
                public string Email { get; set; }
    
                [JsonProperty(PropertyName = "accountEnabled")]
                public bool AccountEnabled { get; set; }
    
                [JsonProperty(PropertyName = "DOB")]
                public string DOB { get; set; }
    
                [JsonProperty(PropertyName = "middleName")]
                public string middleName { get; set; }     
    
                [JsonProperty(PropertyName = "extension_7182f7a071344106a9e47cc960ab93e8_DOB")]
                public string extension_7182f7a071344106a9e47cc960ab93e8_DOB { get; set; }
    
                [JsonProperty(PropertyName = "extension_7182f7a071344106a9e47cc960ab93e8_middleName")]
                public string extension_7182f7a071344106a9e47cc960ab93e8_middleName { get; set; }        
            }
