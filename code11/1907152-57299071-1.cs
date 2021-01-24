    DeviceTimeSeries d = new DeviceTimeSeries { TimeStamp = DateTime.Now, MeasuredValue = 1.23, DateField = "01/01/1970" };
            ProductTimeSeries p = new ProductTimeSeries();
            List<DeviceTimeSeries> dts = new List<DeviceTimeSeries>();
            dts.Add(d);
    
            p.DeviceTimeSeries = dts;
            p.DeviceId = "8787887";
    
            string json = JsonConvert.SerializeObject(p, Formatting.Indented, new CustomJsonConverter(typeof(ProductTimeSeries)));
