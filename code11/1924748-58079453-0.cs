    using Newtonsoft.Json;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Threading.Tasks;
    using System;
    namespace Example
    {
      internal class Example
      {
        private static void Main()
        {
            Execute().Wait();
        }
        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("test@example.com", "Example User"));
            msg.AddTo(new EmailAddress("test@example.com", "Example User"));
            msg.SetTemplateId("d-d42b0eea09964d1ab957c18986c01828");
            var dynamicTemplateData = new ExampleTemplateData
            {
                Subject = "Hi!",
                Name = "Example User",
                Location = new Location
                {
                    City = "Birmingham",
                    Country = "United Kingdom"
                }
            };
            msg.SetTemplateData(dynamicTemplateData);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers.ToString());
            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadLine();
        }
        private class ExampleTemplateData
        {
            [JsonProperty("subject")]
            public string Subject { get; set; }
            
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("location")]
            public Location Location { get; set; }
        }
        private class Location
        {
            [JsonProperty("city")]
            public string City { get; set; }
            
            [JsonProperty("country")]
            public string Country { get; set; }
        }
      }
    }
