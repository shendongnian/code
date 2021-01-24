    class Program
        {
            static void Main(string[] args)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
    
                IConfiguration config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true, true)
              .Build();
    
                List<MiscSettings> miscSettings = config.GetSection("miscSettings")
                        .GetChildren()
                        .ToList()
                         .Select(x => (new MiscSettings
                         {
                             region_code = x.GetValue<string>("region_code"),
                             dbserver = x.GetValue<string>("dbserver"),
                             dbname = x.GetValue<string>("dbname"),
                             url = x.GetValue<string>("url"),
                             hasChapter = x.GetValue<string>("hasChapter")
                         })).ToList();
    
                MiscSettings settingsForEast = miscSettings.Where(x => x.region_code.Equals("east")).FirstOrDefault();
            }
        }
