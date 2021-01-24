public async Task<TObject> Get<TObject>(string controller)
{
    TObject data;
    HttpResponseMessage response = await this.HttpClient.GetAsync(UrlService.BuildEndpoint(controller));
    if (response.IsSuccessStatusCode)
    {
        data = await response.Content.ReadAsAsync<TObject>();
        return data;
    }
    else
    {
        throw new Exception(); //todo
    }
}
Mark the `TObject data;`. This will solve what you mentioned in your edit.
