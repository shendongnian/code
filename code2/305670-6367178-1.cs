    var query = CDC.NCDCPoints
        .Select(n => n.EVENT_TYPE_ID == et 
            && n.BeginDate == b 
            && n.EndDate == e );
    if (query.Any())
    {
        var points = query.ToList();]
        List<NCDCPointsMock> duplicates = new List<NCDCPointsMock>();
        foreach(var point in points)
        {
            NCDCPointsMock dupli = new NCDCPointsMock();
            dupli.ID = point.ID;
            dupli.BeginDate = point.BeginDate;
            dupli.EndDate = point.EndDate;
            dupli.EVENT_TYPE_ID = point.EVENT_TYPE_ID;
            duplicates.Add(dupli);
        }
        return new JavaScriptSerializer().Serialize(dupli);
    }
    else
    {
        return "No duplicate";
    }
