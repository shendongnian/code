public async Task<TObject> Get<TObject>(string controller)
{
    HttpResponseMessage response = await this.HttpClient.GetAsync(UrlService.BuildEndpoint(controller));
    if (response.IsSuccessStatusCode)
    {
        return await response.Content.ReadAsAsync<TObject>();
    }
    else
    {
        throw new Exception(); //todo
    }
}
