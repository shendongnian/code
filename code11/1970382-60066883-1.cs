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
            public string GetMatchedCurrency(string text)
            {
                EductionResponse _eductionResponse = EduceFromTextAsync(text);
                // Line bellow is most likely cause for null exception
                return CleanCurrency(_eductionResponse.autnresponse.responsedata.hit[0].matched_text).TrimEnd();
            }
            public EductionResponse EduceFromTextAsync(string text)
            {
                string url = $"http://{_settings.Hostname}:{_settings.Port}/Action=EduceFromText&Text={text}&responseFormat=simplejson";
                var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                string jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                EductionResponse retval = JsonSerializer.Deserialize<EductionResponse>(jsonString);
                return retval;
            }
            private string CleanCurrency(string currency)
            {
                string remove_dollar_sign = currency.Replace("$", "");
                string remove_comma_sign = remove_dollar_sign.Replace(",", "");
                return remove_comma_sign;
            }
        }
    }
