{
  "configurationSettings": {
    "Token": "...",
    "PreviousVersion": "145.8.3",
    "CurrentVersion": "145.23.4544",
    "Guilds": {
      "this setting": 4
    },
    "Channels": {
      "announcements": 6
    },
    "LatestScheduleMessageID": 456,
    "ConfigurationDirectory": "test"
  }
}
My POCO
 public class MyOptions
    {
        public string Token { get; set; }
        public string PreviousVersion { get; set; }
        public string CurrentVersion { get; set; }
        public Dictionary<string, ulong> Guilds { get; set; }
        public Dictionary<string, ulong> Channels { get; set; }
        public ulong LatestScheduleMessageID { get; set; }
        public string ConfigurationDirectory { get; set; }
        public DateTime GetTimestampFromLastScheduleMessageID(bool toLocalTime = false) =>
            toLocalTime ?
            new DateTime(1970, 1, 1).AddMilliseconds((LatestScheduleMessageID >> 22) + 1420070400000).ToLocalTime() :
            new DateTime(1970, 1, 1).AddMilliseconds((LatestScheduleMessageID >> 22) + 1420070400000);
    }
1. Defile a class to save changes
 public interface IWritableOptions<out T> : IOptions<T> where T : class, new()
    {
        void Update(Action<T> applyChanges);
    }
    public class WritableOptions<T> : IWritableOptions<T> where T : class, new()
    {
        private readonly IHostingEnvironment _environment;
        private readonly IOptionsMonitor<T> _options;
        private readonly string _section;
        private readonly string _file;
        public WritableOptions(
            IHostingEnvironment environment,
            IOptionsMonitor<T> options,
            string section,
            string file)
        {
            _environment = environment;
            _options = options;
            _section = section;
            _file = file;
        }
        public T Value => _options.CurrentValue;
        public T Get(string name) => _options.Get(name);
        public void Update(Action<T> applyChanges)
        {
            var fileProvider = _environment.ContentRootFileProvider;
            var fileInfo = fileProvider.GetFileInfo(_file);
            var physicalPath = fileInfo.PhysicalPath;
            var jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(physicalPath));
            var sectionObject = jObject.TryGetValue(_section, out JToken section) ?
                JsonConvert.DeserializeObject<T>(section.ToString()) : (Value ?? new T());
            applyChanges(sectionObject);
            jObject[_section] = JObject.Parse(JsonConvert.SerializeObject(sectionObject));
            File.WriteAllText(physicalPath, JsonConvert.SerializeObject(jObject, Formatting.Indented));
        }
    }
2. Implemented an extension method for ServiceCollectionExtensions allowing you to easily configure a writable options
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureWritable<T>(
            this IServiceCollection services,
            IConfigurationSection section,
            string file = "appsettings.json") where T : class, new()
        {
            services.Configure<T>(section);
            services.AddTransient<IWritableOptions<T>>(provider =>
            {
                var environment = provider.GetService<IHostingEnvironment>();
                var options = provider.GetService<IOptionsMonitor<T>>();
                return new WritableOptions<T>(environment, options, section.Key, file);
            });
        }
    }
2. Please add the following code in Startup.cs
 public void ConfigureServices(IServiceCollection services)
        {
            var configBuilder = new ConfigurationBuilder()
                                   .SetBasePath(Directory.GetCurrentDirectory())
                                   .AddJsonFile("Config.json", optional: false, reloadOnChange:true);
            var config = configBuilder.Build();
            services.ConfigureWritable<MyOptions>(config.GetSection("configurationSettings"));
   
            ...
        }
3. Change the Json vaule
 private readonly IWritableOptions<Locations> _writableLocations;
        public OptionsController(IWritableOptions<Locations> writableLocations)
        {
            _writableLocations = writableLocations;
        }
        
        //Update LatestScheduleMessageID 
        public IActionResult Change(string value)
        {
            _writableLocations.Update(opt => {
                opt.LatestScheduleMessageID = value;
            });
            return Ok("OK");
        }
4. Read the JSON value
private readonly IOptionsMonitor<MyOptions> _options;
        public HomeController(ILogger<HomeController> logger, IHostingEnvironment env, IOptionsMonitor<MyOptions> options)
        {
            _logger = logger;
            _env = env;
            _options = options;
        }
 public IActionResult Index()
        {
           var content= _env.ContentRootPath;
           var web = _env.WebRootPath;
            @ViewBag.Message = _options.CurrentValue.LatestScheduleMessageID;
            return View();
        }
 5. Result 
First
[![enter image description here][1]][1]
After change:
[![enter image description here][2]][2]
  [1]: https://i.stack.imgur.com/Q8GY1.png
  [2]: https://i.stack.imgur.com/sU2qk.png
