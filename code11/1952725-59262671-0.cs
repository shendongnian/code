    [HttpGet("{materialId}")]
    public string GetPipeMaterial(int materialId)
    {
        using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44317/api/MaterialDescription/5");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
               
            }
        return "";
    }
