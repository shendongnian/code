     PerformanceCounter systemUpTime = new PerformanceCounter("System", "System Up Time");
     
     systemUpTime.NextValue();
     TimeSpan upTimeSpan = TimeSpan.FromSeconds(systemUpTime.NextValue());
     Console.Out.WriteLine(DateTime.Now.Subtract(upTimeSpan).ToShortTimeString());
