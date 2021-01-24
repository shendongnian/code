    try {
                    SelfLog.WriteLine($"Sending batch of {logEventsBatch.Count} messages to DocumentDB");
                    var storedProcedureResponse = await _client
                                                       .ExecuteStoredProcedureAsync<int>(_bulkStoredProcedureLink, args)
                                                       .ConfigureAwait(false);
                    SelfLog.WriteLine(storedProcedureResponse.StatusCode.ToString());
    
                    return storedProcedureResponse.StatusCode == HttpStatusCode.OK;
                }
