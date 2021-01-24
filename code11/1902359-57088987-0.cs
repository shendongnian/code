    string apiUrl = "https://api.host/csv-upload/api-key?remove-hosts=false;
    
                HttpClient client = new HttpClient();
    
                //Prepare request header
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                client.DefaultRequestHeaders.Add("Api-Key", "xxxyyyzzz");
    
    
                //cache
                CacheControlHeaderValue cacheControl = new CacheControlHeaderValue();
                cacheControl.NoCache = true;
                client.DefaultRequestHeaders.CacheControl = cacheControl;
    
                byte[] bytes = File.ReadAllBytes(csvFilePath); //c://Temp/test.csv
                HttpContent fileContent = new ByteArrayContent(bytes);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");
    
    
                try
                {
                    
    				var response = await httpClient.PostAsync(apiUrl , new MultipartFormDataContent
    						{
    							{fileContent, "\"file\"", "\"test.csv\""}
    						});
                }
                catch(Exception ex)
                {
                    string message = ex.Message;
                    Console.WriteLine(message); ;
                }
                finally
                {
                    Console.WriteLine("Error");
                }`
