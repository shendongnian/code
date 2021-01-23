    var  cw =AWSClientFactory.CreateAmazonCloudWatchClient("AccessKey","secretkey",Amazon.RegionEndpoint.USWest2);
        DataTable data = new DataTable();
        try
        {
            Dimension dim = new Dimension() { Name = "InstanceId", Value = "InstanceId of you EC2 Server" };
            System.Collections.Generic.List<Dimension> dimensions = new List<Dimension>() { dim };
            string  startTime1 = DateTimeOffset.Parse(DateTime.Now.AddHours(-30).ToString()).ToUniversalTime().ToString("s"); // "2010-09-29T11:00:00+01:00";
            GetMetricStatisticsRequest reg = new GetMetricStatisticsRequest()
            {
                MetricName = "CPUUtilization",
                Period = 1800,
                Statistics = new System.Collections.Generic.List<string>() { "Average","Minimum","Maximum" },
                Dimensions = dimensions,
                Namespace = "AWS/EC2",
                EndTime = DateTime.Now, //Convert.ToDateTime(DateTime.Now.ToUniversalTime().ToString("s")), //has to be in this format: 2010-09-29T14:00:00+01:00;
                StartTime = DateTime.Now.AddHours(Convert.ToInt32(-15)),// Convert.ToDateTime(startTime1),
            };
            var points = cw.GetMetricStatistics(reg).GetMetricStatisticsResult.Datapoints.OrderBy(p => p.Timestamp);
            data.Columns.Add("Average");
            data.Columns.Add("TimeStamp");
            foreach (var p in points)
            {
                DataRow row = data.NewRow();
                row["Average"] = Math.Round(p.Average, 0);
                row["TimeStamp"] = p.Timestamp; //DateTimeOffset.Parse(Convert.ToDateTime(p.Timestamp)).LocalDateTime.ToString("yyyy-MM-dd HH:mm");
                data.Rows.Add(row);
            }
            dataGridView1.DataSource = data;
           
        }
        catch (AmazonCloudWatchException ex)
                {
                    if (ex.ErrorCode.Equals("OptInRequired"))
                        throw new Exception("You are not signed in for Amazon EC2.");
                    else
                        throw;
                }
