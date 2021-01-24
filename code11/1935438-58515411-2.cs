var response = await client.GetAsync(apiUri.Uri);   
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
*(You can move `var text = ...` outside of `if` if you wish.)* 
----
Status code can be examined instead of calling `IsSuccessStatusCode`, if needed.
if (response.StatusCode != HttpStatusCode.OK) // 200
{
    throw new Exception(); / return null  et.c
}
