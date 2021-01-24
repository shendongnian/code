    var myContent = "your string in here";
    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
    var byteContent = new ByteArrayContent(buffer);
    
    using (HttpResponseMessage response = client.PostAsync("https://sandbox-quickbooks.api.intuit.com/v3/company/1232/query?minorversion=8",bytecontent).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync().Result;
                    }
                }
