    foreach (var dataRecord in myList)
    {
        var minutes = dataRecord.MeasurementDate.Hour * 60 + dataRecord.MeasurementDate.Minute;
        var before = myList.Where(x =>
            x.MeasurementDate.Hour * 60 + x.MeasurementDate.Minute >= minutes - 60 &&
            x.MeasurementDate.Hour * 60 + x.MeasurementDate.Minute <= minutes).ToList();
        var after = myList.Where(x =>
            x.MeasurementDate.Hour * 60 + x.MeasurementDate.Minute <= minutes + 60 &&
            x.MeasurementDate.Hour * 60 + x.MeasurementDate.Minute >= minutes).ToList();
        if (before.Count > result.Count ||
            after.Count > result.Count)
        {
            result = before.Count > after.Count ? before.ToList() : after.ToList();
        }
    }
