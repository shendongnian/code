csharp
public async Task<Dictionary<int, object>> ExecuteSelectAsync (string statement)
{
    // declare the TaskCompletionSource that will hold the database results
    var tcs = new TaskCompletionSource<Dictionary<int, object>>();
    DatabaseLibrary.execute(
        statement,
        new Action<dynamic> (s =>
        {
            // Take the data returned as 's' and populate the 'responseData' dictionary.
            Utility.LogDebug("Database", "Executed select statement with " + numberOfRows.ToString() + " rows");
            var data = new Dictionary<int, object>();
            // build your dictionary here
            // the work is now complete; set the data on the TaskCompletionSource
            tcs.SetResult(data);
        })
    );
    // wait for the response data to be created
    var responseData = await tcs.Task;
    Utility.LogDebug("Database", "Returning select execution response"); 
    return responseData;
    // if you don't need the logging, you could delete the three lines above and
    // just 'return tcs.Task;' (or move the logging into the callback)
}
