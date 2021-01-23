    var urls = new List<string>();
    
                var tasks = urls.Select(url =>
                    {
                        var request = WebRequest.Create(url);
                        var task = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
                        task.Start();
                        return task;
                    }).ToArray();
    
                Task.WaitAll(tasks);
    
                foreach (var task in tasks)
                {
                    using (var response = task.Result)
                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        var html = reader.ReadToEnd();
                    }                                
                }
