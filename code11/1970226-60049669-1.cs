    public async Task<IActionResult> OnPostUpdateAlarmDataTableAsync() {
        try {
            await _adoNetRepository.FillAlarmsDataTable();
            return Ok(); //200 OK
        catch(Exception ex) {
            //...log the exception returned from the task that failed!
            
            return new ExceptionResult(ex, includeErrorDetail:true);
        }
    }
