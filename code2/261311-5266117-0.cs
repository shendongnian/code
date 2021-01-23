    foreach(var processData in value.ProcessDatas)
    {
        foreach(var measurement in processData.Measurements)
        {
            measurement.PropertyChanged += OnMeasurementPropertyChanged;
        }
    }
