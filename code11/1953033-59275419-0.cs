    public class FileWriterService : IHostedService, IDisposable {
        private const string Path = @"d:\TestApplication.txt";
    
        private Timer _timer;
        private AppVars _appVars;
        public FileWriterService(IOptions<AppVars> appVars) {
           _appVars = appVars.Value;
        }
        //...
    }
