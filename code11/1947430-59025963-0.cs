private List<Highlight > HighlightList = new List<Highlight>();
                   string urlPath = link;
                    var httpClient = new HttpClient(new HttpClientHandler());
 var values = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("SCH-API-KEY", "SCH_KEnaBiDeplebt")
                    };
                    var response = await httpClient.PostAsync(urlPath, new FormUrlEncodedContent(values));
                    response.EnsureSuccessStatusCode();
 string jsonText = await response.Content.ReadAsStringAsync();
                    try
                    {
                        JsonObject jsonObject = JsonObject.Parse(jsonText);
                        JsonObject jsonData = jsonObject["data"].GetObject();
                        JsonObject bukuBObject = jsonData.ContainsKey("buku_baru") && jsonData["buku_baru"] != null ? jsonData["buku_baru"].GetObject() : JsonObject.Parse("");
                        try 
                        { 
                          Highlight highlight = new Highlight();
                           string title = "";
 
                            title = bukuBObject["title"].GetString();
                             
                          HighlightList.Add(highlight);
                        }
                        catch
                        {
                        }
                        JsonObject komikPObject = jsonData.ContainsKey("komik_popular") && jsonData["komik_popular"] != null ? jsonData["komik_popular"].GetObject() : JsonObject.Parse("");
                        try
                        {
                            Highlight highlight = new Highlight();
                           string title = "";
                            title = komikPObject["title"].GetString();
                            HighlightList.Add(highlight);
                        }
                        catch
                        {
                        }
                  }
                  catch()
                   {
                    }
                       foreach( Highlight items in HighlightList)
                      {
                        Debug.WriteLine("judul: " + items .Title);
                      }
}
