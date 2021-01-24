    [HttpGet]
    public async Task<ActionResult> Get(string id){
        string DealerId = await PairingTable.GetDealerId(id);
        if (string.IsNullOrEmpty(DealerId)) {
            var result = new ReturnResult {
                status = "Fail",
                data = "ID is invalid"
            };
            return NotFound(result);
        }
        SettingsInfo info = await DealerSettingsTable.GetSettingsInfo(DealerId);
        if (info == null) {
            var result = new ReturnResult {
                status = "Fail",
                data = "Not Found"
            };
            return NotFound(result);
        }
        var result = new ReturnResult {
            status = "Success",
            data = info
        };
        return Ok(result);
    }
