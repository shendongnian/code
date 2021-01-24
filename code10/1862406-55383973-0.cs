    using System;
    using Newtonsoft.Json;
    
    namespace DynamicErrorsJson
    {
        public class ApiResponse
        {
            public dynamic Errors { get; set; }
    
            public string ErrorsString
            {
                get
                {
                    string value = string.Empty;
                    if (Errors != null)
                    {
                        value = Errors.ToString();
                    }
    
                    return value;
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var listErrorsJson = @"{ ""errors"": {""invalid_player_ids"" : [""5fdc92b2-3b2a-11e5-ac13-8fdccfe4d986"", ""00cb73f8-5815-11e5-ba69-f75522da5528""] } }";
                var stringErrorsJson = @"{ ""errors"": [""Notification content must not be null for any languages.""] }";
                var noErrorsJson = @"{""errors"": """" }";
    
                var listErrorsResponse = JsonConvert.DeserializeObject<ApiResponse>(listErrorsJson);
                var stringErrorsJsonResponse = JsonConvert.DeserializeObject<ApiResponse>(stringErrorsJson);
                var noErrorsJsonResponse = JsonConvert.DeserializeObject<ApiResponse>(noErrorsJson);
    
                Console.WriteLine("listErrorsJson Response: {0}\n\t", listErrorsResponse.ErrorsString);
                Console.WriteLine("stringErrorsJson Response: {0}\n\t", stringErrorsJsonResponse.ErrorsString);
                Console.WriteLine("noErrorsJson Response: {0}\n\t", noErrorsJsonResponse.ErrorsString);
                Console.WriteLine();
                Console.WriteLine("Press a key to exit...");
    
                Console.ReadKey();
            }
        }
    }
