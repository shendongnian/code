response.RequestMessage
or
var text = await response.Content.ReadAsStringAsync();
In your case the code would be something like 
using(var response = await client.GetAsync(...))   
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
