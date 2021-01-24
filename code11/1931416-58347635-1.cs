                var internalLinks = new List<InternalLinksModel>();
                // Populate InternalLinks with the data
                // I'm assuming this means internalLinks is assumed to contain data. If not I'm not sure I understand your code.
                var dictionary = new Dictionary<Task, InternalLinksModel>(); //You shouldn't need a concurrent dictionary since you'll only be doing reads in parallel.
    
                //make api calls - I/O bound
                foreach (var l in internalLinks)
                {
                    dictionary[client.ExecuteTaskAsync(l.SearchValue)] = l;
                }
    
                await Task.WhenAll(dictionary.Keys);    
                // I/O is done.
                
                // Compute bound - deserialize, validate, assign.
                Parallel.ForEach(dictionary.Keys, (task) =>
                {
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel>(task.Result.Content);
                    dictionary[task].PossibleResults = ValidateSearchResult(responseModel);
                });
    
    
                // Writes results to txt file
                WriteResults(dictionary.Values, "Internal Links");
