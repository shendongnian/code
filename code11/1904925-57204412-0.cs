    MyScreenClass mol = new MyScreenClass{ TicketReportPropertyEntities = new List<TicketReportPropertyEntity>()};
    mol.TicketReportPropertyEntities.Add(new TicketReportPropertyEntity
    {
        ReportProperty = new ReportPropertyEntity
        {
            PropertyName = "CoolPropertyName"
        }
    });
    string propertyToSearchFor = "CoolPropertyName";
    foreach (var ticketReportEntity in mol.TicketReportPropertyEntities)
    {
        var type = ticketReportEntity.GetType();
        //Get PropertyInfo objects
        PropertyInfo reportProperty = type.GetProperty("ReportProperty");
        PropertyInfo reportPropertyName = typeof(ReportPropertyEntity).GetProperty("PropertyName");
        PropertyInfo amountProperty = type.GetProperty("Amount");
        //Get needed values
        ReportPropertyEntity reportPropertyValue = (ReportPropertyEntity)reportProperty.GetValue(ticketReportEntity);
        string reportPropertyNameValue = (string)reportPropertyName.GetValue(reportPropertyValue);
        
        //Check if change is required
        if (reportPropertyNameValue == propertyToSearchFor)
        {
            amountProperty.SetValue(ticketReportEntity, 123.45M);
        }
    }
