    var results = new List<YourResultType>;
    foreach(var order in orders){
                var result = new VendorTaskResult();
                try
                {
                    result.Response = await result.CallVendorAsync();
                    results.Add(result.Response);
                }
                catch(Exception ex)
                {
                    result.Exception = ex;
                }
    }
