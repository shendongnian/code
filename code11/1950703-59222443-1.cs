    public void LogEvent(RequestModel<List<Event>> request)
    {
        foreach (var eventItem in request.Model)
        {
            try
            {
                var logData = new CreditCardLog()
                {
                    AppraisalFormID = ApparisalId,
                    CreatedBy = "UserID",
                    CreatedDate = request.LogDate,
                    LogID = Guid.NewGuid(),
                    Data = new JavaScriptSerializer().Serialize(eventItem)
                };
                _creditCardLogService.Add(logData);
            }
            catch (Exception ex)
            {
                continue;
            }
        }
    }
