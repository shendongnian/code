    public interface ILogger
    {
      string Id { get; }
    }
    public class FileLogger : ILogger
    {
      public string Id { get { return "Logger.File"; } }
    }
    // etc.
    public interface IStorage
    {
      string Id { get; }
    }
    public class RegistrySrorage : IStorage
    {
      public string Id { get { return "Storage.Registry"; } }
    }
    public class MyService
    {
      IList<Config> _EnabledConfigs;
      public MyService(IEnumerable<ILogger> loggers, IEnumerable<IStorage> storages)
      {
        _EnabledConfigs = ParseXmlConfigAndCreateRequiredCombinations(loggers, storages);
      }
      class Config
      {
        public ILogger Logger { get; set; }
        public IStorage Storage { get; set; }
      }
    }
    // container config:
    public static void ConfigureContainer(IContainerBuilder builder)
    {
      builder.RegisterType<FileLogger>.AsImplementedInterfaces();
      // other loggers next...
      builder.RegisterType<RegisterStorage>.AsImplementedInterfaces();
      // then other storages
      builder.RegisterType<MyService>();
    }
