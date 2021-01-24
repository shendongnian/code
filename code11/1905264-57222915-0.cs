    //here I need to find out if the ObjectAEntity has the same property as ReportProperty
    //Attempt to grab the PropertyInfo that you want to set
    var objectAEntityReportProperty = bo.GetType().GetProperty(reportPropertyNameValue);
    //If it is not null, you have found a match
    var has = objectAEntityReportProperty != null;
    if (has)
    {
        //need to set the value of the Model's `ObjectAEntity` property
        //Then, set the value
        objectAEntityReportProperty.SetValue(bo, ticketReportEntity.Amount);
    }
