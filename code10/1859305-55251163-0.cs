    private async Task FillTimes()
    {
       var strResponse = await CallJsonAsync($"RESTAPI URL");
       if (strResponse != null)
       {
          var jResult = JsonConvert.DeserializeObject<JsonResults>(strResponse);
    
          BindingSource bsResults = new BindingSource();
          bsResults.DataSource = jResult.Results;
    
          if (bsResults.DataSource != null)
          {
             DgvOnline.DataSource = bsResults.DataSource;
          }
       }
    }
