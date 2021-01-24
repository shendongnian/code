public ActionResult CreateRequest([FromBody] DnsRecordDto RecordRequested)
{
    var result = IsRecordRequestedNull()
}
If there is an asynchronous version of that `SaveLogItem` method, then you could await it and make everything `async`:
public async Task<ActionResult> CreateRequest([FromBody] DnsRecordDto RecordRequested)
{
    var result = await IsRecordRequestedNull()
}
public async Task<bool> IsRecordRequestedNull(DnsRecordDto RecordRequested)
{
    bool flag = false;
    if (RecordRequested == null)
    {
        flag = true;
        await _commonRepository.SaveLogItemAsync(Constants.TransactionFailedBadData, Constants.STARTING, transId, LogLevel.Trace);
    }
    return flag;
}
But I don't know where that `SaveLogItem` method is coming from, so I can't say if there is an async version available to you.
