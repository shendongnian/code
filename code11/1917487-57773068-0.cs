var response = await _httpClient.PostAsync("api/account/auth", authModel);
if (response.IsSuccessStatusCode)
{
    //parse result as following
    using (var sr = await response.Content.ReadAsStreamAsync())
    {
        var parsedResult = JsonSerializer.DeserializeAsync<RecipeDetailDto>(sr);
    }
}
else
{
    //If the bad request content/body is a json object
    //parse error content
    using (var sr = await response.Content.ReadAsStreamAsync())
    {
        //If the bad request content is a json
        //var parsedErrorResult = JsonSerializer.DeserializeAsync<yourErroObjset>(sr);
    }
    //OR if the content is string
    var errorResult = await response.Content.ReadAsString();
}
Did not testet it, but it should give you the context how to approach this.
