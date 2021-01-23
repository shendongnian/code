    var query = (from n in CDC.NCDCPoints
                 where n.EVENT_TYPE_ID == et && n.BeginDate == b && n.EndDate == e
                 select new 
                 {
                     EventTypeId = n.EVENT_TYPE_ID,
                     BeginDate = n.BeginDate,
                     EndDate = n.EndDate,
                     ... // add the other properties you need on the client side
                 });
    if (query.Any())
    {
        return new JavaScriptSerializer().Serialize(query.ToList());
    }
    else
    {
        return "No duplicate";
    }
