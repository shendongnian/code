    public async Task<IActionResult> OnPostUpdateAlarmDataTableAsync() {
        
        var result = await _adoNetRepository.FillAlarmsDataTable();
        if (!result.Succeeded) {
            // log the exception returned from the task that failed!
            //result.Errors
        }
        return new JsonResult(result);
    }
