    AmazonCloudWatch cw = AWSClientFactory.CreateAmazonCloudWatchClient(accessKey, secretKey, new AmazonCloudWatchConfig().WithServiceURL("https://eu-west-1.monitoring.amazonaws.com"));
    
            DataTable data = new DataTable();
            try
            {
                Dimension dim = new Dimension() { Name = "InstanceId", Value = GetInstanceName(amazonInstance) };
                System.Collections.Generic.List<Dimension> dimensions = new List<Dimension>() { dim };
    
                string startTime = startTime = DateTimeOffset.Parse(DateTime.Now.AddDays(-2).ToString()).ToUniversalTime().ToString("s"); // "2010-09-29T11:00:00+01:00";
    
                GetMetricStatisticsRequest reg = new GetMetricStatisticsRequest()
                {
                    MeasureName = "CPUUtilization",
                    Period = 1800
                    Statistics = new System.Collections.Generic.List<string>() { "Average" },
                    Dimensions = dimensions,
                    Namespace = "AWS/EC2",
                    EndTime = DateTime.Now.ToUniversalTime().ToString("s"), //has to be in this format: 2010-09-29T14:00:00+01:00;
                    StartTime = startTime
                };
    
                var points = cw.GetMetricStatistics(reg).GetMetricStatisticsResult.Datapoints.OrderBy(p => p.Timestamp);
    
                data.Columns.Add("Average");
                data.Columns.Add("TimeStamp");
                foreach (var p in points)
                {
                    DataRow row = data.NewRow();
                    row["Average"] = Math.Round(p.Average, 0);
                    row["TimeStamp"] = DateTimeOffset.Parse(p.Timestamp).LocalDateTime.ToString("yyyy-MM-dd HH:mm");
    
                    data.Rows.Add(row);
                }
            }
        catch (AmazonCloudWatchException ex)
                    {
                        if (ex.ErrorCode.Equals("OptInRequired"))
                            throw new Exception("You are not signed in for Amazon EC2.");
                        else
                            throw;
                    }
