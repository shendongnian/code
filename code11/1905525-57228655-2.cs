    @Code
        var items =  DocumentDBRepository<CosmosDBTelemetry>.GetDeviceIds();
        List<string> deviceids = new List<string>();
        foreach(var item in items)
         {
         deviceids.Add(item.deviceId);
         }
    End Code
    <select>
        <option value="">Select an option</option>
      @foreach (string deviceid in deviceids)
      {
        <option value="@deviceid">@deviceid</option>
      }
    </select> 
    
