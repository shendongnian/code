       public static void Main(string[] Args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    
              List<string> strings = new List<string>() {};
            for (double d = 0; d < 8000000; d++) {
                strings.Add(d.ToString());
            }
    
            TimeSpan upTime;
            TimeSpan newupTime;
            using (var pc = new PerformanceCounter("System", "System Up Time"))
            {
                StringBuilder sb = new StringBuilder();
                int i;
    
                pc.NextValue();    //The first call returns 0, so call this twice
                upTime = TimeSpan.FromSeconds(pc.NextValue());
    
                for (i = 0; i < strings.Count - 1; i++)
                {
                    sb.Append(strings[i]);
                    sb.Append(",");
                }
                sb.Append(strings[i]);
    
                newupTime = TimeSpan.FromSeconds(pc.NextValue());
                sb = null;
                Console.WriteLine("SB " + (newupTime - upTime).TotalMilliseconds);
            }
      
            using (var pc = new PerformanceCounter("System", "System Up Time"))
            {
    
                pc.NextValue();
                upTime = TimeSpan.FromSeconds(pc.NextValue());
    
                string s = string.Join(",", strings);
    
                newupTime = TimeSpan.FromSeconds(pc.NextValue());
                Console.WriteLine("JOIN " + (newupTime - upTime).TotalMilliseconds);
            }
            
    
        }
    SB 406
    JOIN 484
