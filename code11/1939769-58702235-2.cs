    bool hasName = dataTable.Columns.Contains("Name");
    bool hasDate = dataTable.Columns.Contains("Date");
    bool hasimageUrl = dataTable.Columns.Contains("imageUrl");
    bool hasMonth = dataTable.Columns.Contains("Month");
    bool hasLon = dataTable.Columns.Contains("Lon");
    bool hasLat = dataTable.Columns.Contains("Lat");
    var envelope = new
    {
      // use: ReportMonth = hasMonth ? ... : ... ;
    }
