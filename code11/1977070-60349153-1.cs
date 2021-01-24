    [StorageAccount("AzureWebJobsStorage")]
    public class BlobFunction
    {
        private readonly IInternalYoutubeService _YoutubeService;
        private readonly ILogger _Logger;
        // We inject the YoutubeService    
        public BlobFunction(IInternalYoutubeService youtubeService, ILogger<BlobFunction> logger)
        {
            _YoutubeService = youtubeService;
            _Logger = logger;
        }
    
        [FunctionName("Function1")]
        public async void Run(
            [BlobTrigger("youtube-files/{filename}.{extension}")] Stream blob,
            [Blob("youtube-files-descriptions/{filename}-description.txt")] string description,
            string filename,
            string extension)
        {
            switch (extension)
            {
                case "mp4":
                    await _YoutubeService.UploadVideo(blob, filename, description, "Some tag", "Another tag", "An awesome tag");
                    break;
    
                case "mp3":
                    await _YoutubeService.UploadAudio(blob, filename, description);
                    break;
    
                default:
                    _Logger.LogInformation($"{filename}.{extension} not handled");
                    break;
            }
        }
    }
