var response = await client.GetAsync(apiUri.Uri);   
{
    if (!response.IsSuccessStatusCode)
    {
        var text = await response.Content.ReadAsStringAsync();
        // Log error
        return null; // throw etc.
    }
    else 
    {
        var text = await response.Content.ReadAsStringAsync();
        var o = JsonConvert.DeserializeObject<Questions<Question>>(o);
        return o;
    }   
}
