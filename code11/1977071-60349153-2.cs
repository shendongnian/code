    public interface IInternalYoutubeService
    {
        Task UploadVideo(Stream stream, string title, string description, params string[] tags);
        Task UploadAudio(Stream stream, string title, string description, params string[] tags);
    }
    
    internal class InternalYoutubeService : IInternalYoutubeService
    {
        private readonly IConfiguration _Configuration;
        private readonly ILogger _Logger;
    
        public InternalYoutubeService(IConfiguration configuration, ILogger<InternalYoutubeService> logger)
        {
            _Configuration = configuration;
            _Logger = logger;
        }
    
        public async Task UploadAudio(Stream stream, string title, string description, params string[] tags)
        {
            _Logger.LogInformation($"{_Configuration["YoutubeAccountName"]}");
            _Logger.LogInformation($"{_Configuration["YoutubeAccountPass"]}");
            _Logger.LogInformation($"Bytes: {stream.Length} - {title} - {description} - {string.Join(", ", tags)}");
        }
    
        public async Task UploadVideo(Stream stream, string title, string description, params string[] tags)
        {
            _Logger.LogInformation($"{_Configuration["YoutubeAccountName"]}");
            _Logger.LogInformation($"{_Configuration["YoutubeAccountPass"]}");
            _Logger.LogInformation($"Bytes: {stream.Length} - {title} - {description} - {string.Join(", ", tags)}");
        }
    }
