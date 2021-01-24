    // Note that I made this method async.
    public async Task<IActionResult> GetDataFromExternal()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(ExternalApiLink);
    
            // note that I moved this line above the GetAsync method.
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "XXXX");
            using (var response = await client.GetAsync(ExternalApiLinkGet))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Since the response content is json, but the content-type
                    // is text/html, simply read the content as a string.
                    string content = await response.ReadAsStringAsync();
    
                    // You can return the actual received content like below,
                    // or you may deserialize the content before returning to make
                    // sure it is correct, using JsonConvert.DeserializeObject<List<ExternalApi>>()
                    // var data = JsonConvert.DeserializeObject<List<ExternalApi>>(content);
                    // return Json(data);
                    return Content(content, "application/json");
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
