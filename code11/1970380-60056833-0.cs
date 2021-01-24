csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EductionAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace EductionAPI.Controllers
{
    [Route("api/[controller]/{text}")]
    [ApiController]
    public class MoneyEductionController : ControllerBase
    {
        private IConfiguration _configuration;
        public MoneyEductionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<MoneyEduced> EduceFromTextAsync(string text)
        {
            var retVal = new MoneyEduced();
            var eductionService = new EductionService(_configuration);
            string matched_text = await eductionService.GetMatchedCurrencyAsync(text);
            retVal.CurrencyValue = matched_text;
            return retVal;
        }
    }
}
csharp
using EductionAPI.ConfigurationModels;
using EductionAPI.Services.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace EductionAPI.Services
{
    public class EductionService
    {
        private HttpClient _httpClient;
        public EductionSettings _settings { get; set; }
        public EductionService(IConfiguration configuration)
        {
            EductionSettings eductionSettings = new EductionSettings(configuration);
            _httpClient = new HttpClient();
            _settings = eductionSettings;
        }
        public async Task<string> GetMatchedCurrencyAsync(string text)
        {
            EductionResponse autnResponse = await EduceFromTextAsync(text);
            // Line bellow is most likely cause for null exception
            return autnResponse.Autnresponse.responsedata.hit[0].matched_text;
        }
        public async Task<EductionResponse> EduceFromTextAsync(string text)
        {
            string url = $"http://{_settings.Hostname}:{_settings.Port}/Action=EduceFromText&Text={text}&responseFormat=simplejson";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<EductionResponse>(responseStream);
        }
    }
}
