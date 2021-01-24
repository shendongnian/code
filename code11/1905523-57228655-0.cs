    public async Task<IActionResult> PopulateDropDownList()
    {
        var items = await 
                    DocumentDBRepository<CosmosDBTelemetry>.GetDeviceIds();
                    List<string> deviceids = new List<string>();
        foreach(var item in items)
        {
         deviceids.Add(item.deviceId);
        }
        ViewData["deviceids"] = deviceids;
        return View();
    }
