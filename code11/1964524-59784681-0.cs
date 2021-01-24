    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    
    namespace Microsoft.BotBuilderSamples.Controllers
    {
        [Route("api/token")]
        [ApiController]
        public class TokenController : ControllerBase
        {
            
           
            [HttpGet]
            public async Task<ObjectResult> getToken()
            {
                var secret = "<direct line secret here>";
    
                HttpClient client = new HttpClient();
    
                HttpRequestMessage request = new HttpRequestMessage(
                    HttpMethod.Post,
                    $"https://directline.botframework.com/v3/directline/tokens/generate");
    
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", secret);
    
                var userId = $"dl_{Guid.NewGuid()}";
    
                request.Content = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(
                        new { User = new { Id = userId } }),
                        Encoding.UTF8,
                        "application/json");
    
                var response = await client.SendAsync(request);
                string token = String.Empty;
    
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    token = JsonConvert.DeserializeObject<DirectLineToken>(body).token;
                }
    
                var config = new ChatConfig()
                {
                    token = token,
                    userId = userId
                };
    
                return Ok(config);
            }
        }
        public class DirectLineToken
        {
            public string conversationId { get; set; }
            public string token { get; set; }
            public int expires_in { get; set; }
        }
        public class ChatConfig
        {
            public string token { get; set; }
            public string userId { get; set; }
        }
    }
