    var minimumMinutes = myList.Min(x => x.MeasurementDate.Hour * 60 + x.MeasurementDate.Minute);
    var maximumMinutes = myList.Max(x => x.MeasurementDate.Hour * 60 + x.MeasurementDate.Minute);
    for (int minutes = minimumMinutes; minutes < maximumMinutes; minutes++)
    {
        var list = myList.Where(x =>
            x.MeasurementDate.Hour * 60 + x.MeasurementDate.Minute <= minutes + 60 &&
            x.MeasurementDate.Hour * 60 + x.MeasurementDate.Minute >= minutes);
        if (result.Count < list.Count())
        {
            result = list.ToList();
        }
    }
