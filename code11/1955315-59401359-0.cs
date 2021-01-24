    var chartResourceUrl = graphClient.Me.Drive.Items[itemId]
             .Workbook
             .Worksheets[nameSheet]
             .Charts[chartName]
             .Request().RequestUrl;
                
                
     var urlToGetImageFromChart = $"{chartResourceUrl}/image(width=400, height=480)";
     var message = new HttpRequestMessage(HttpMethod.Get, urlToGetImageFromChart);
     await graphClient.AuthenticationProvider.AuthenticateRequestAsync(message);
     var response = await graphClient.HttpProvider.SendAsync(message);
     if (response.IsSuccessStatusCode)
     {
         var content = await response.Content.ReadAsStringAsync();
         JObject imageObject = JObject.Parse(content);
         JToken chartData = imageObject.GetValue("value"); 
         //...
     }
