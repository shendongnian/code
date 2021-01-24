                foreach (var post in list)
                {
                    async Task<string> func()
                    {
                        var response = await client.GetAsync("posts/" + post);
                        return await response.Content.ReadAsStringAsync();
                    }
    
                    tasks.Add(func());
                }
    
                await Task.WhenAll(tasks);
    
                var postResponses = new List<string>();
                
                foreach (var t in tasks) {
                    var postResponse = await t; //t.Result would be okay too.
                    postResponses.Add(postResponse);
                    Console.WriteLine(postResponse);
                }
