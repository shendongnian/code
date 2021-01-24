using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SlackExamples
{
    class CreateChannels
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task CreateChannel()
        {
            var values = new Dictionary<string, string>
            {
                { "token", Environment.GetEnvironmentVariable("SLACK_TOKEN") },
                { "name", "cool-guys" }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://slack.com/api/conversations.create", content);
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
        }
        static void Main(string[] args)
        {
            CreateChannel().Wait();
        }
    }
}
Note: The token you need it kept in an environment variable for security purposes, which is good practice.
  [1]: https://api.slack.com/methods/conversations.create
