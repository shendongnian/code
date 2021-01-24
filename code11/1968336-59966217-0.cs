    var rootList = JsonConvert.DeserializeObject<List<RootObject>>(json);
    var result = new List<List<Report>>();
    foreach (var rootObj in rootList)
    {
        for (int i = 0; i < rootObj.TicketSales.Count; i++)
        {
            if (i >= result.Count)
            {
                result.Add(new List<Report>());
            }
            result[i].Add(new Report
            {
                Title = rootObj.Title,
                Sum = rootObj.TicketSales[i].Sum,
                Quantity = rootObj.TicketSales[i].Quantity,
                Sessions = rootObj.TicketSales[i].Sessions
            });
        }
    }
