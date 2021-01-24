                var client = new TelemetryClient();
                TelemetryConfiguration.Active.InstrumentationKey = "xxxxx";
                AvailabilityTelemetry a = new AvailabilityTelemetry();
                a.Name = "this is your_web_site_name or other unique value";
                
                //or some properties like below
                //a.Properties.Add("p1", "my internal web");
    
                client.TrackAvailability(a);
