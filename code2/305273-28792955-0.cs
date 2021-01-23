    var smartSeriesMapping = new SeriesMapping
    {
        LegendLabel = "smartSeries",
        SeriesDefinition = new LineSeriesDefinition()
    };
    smartSeriesMapping.ItemMappings.Add(new ItemMapping("Time", DataPointMember.XCategory));
    smartSeriesMapping.ItemMappings.Add(new ItemMapping("SmartVal", DataPointMember.YValue));
    smartSeriesMapping.SeriesDefinition.ShowItemLabels = false; //This line make lables go away :D
    SmsRadChart.SeriesMappings.Add(smartSeriesMapping);
