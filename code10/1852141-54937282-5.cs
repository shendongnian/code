    public class DefaultImageProcessingService : IImageProcessingService
    {
        public DefaultImageProcessingService
        (
            IImageResizerService resizer,
            String defaultFileName = null,
            Int32 maxSaveAttempts = 3
        )
        {
            this.resizer    = resizer ?? throw new ArgumentNullException( nameof(resizer) );
        }
        public DefaultImageProcessingService
        (
            IImageSavingService saver,
            IImageObjectRecognizerService recognizer,
            String defaultFileName = null,
            Int32 maxSaveAttempts = 3
        )
        {
            this.saver      = saver   ?? throw new ArgumentNullException( nameof(saver) );
            this.recognizer = recognizer?? throw new ArgumentNullException( nameof(recognizer) );
        }
    }
