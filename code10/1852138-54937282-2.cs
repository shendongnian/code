    public class DefaultImageProcessingService : IImageProcessingService
    {
        public DefaultImageProcessingService
        (
            IImageResizerService resizer,
            IImageSavingService saver,
            IImageObjectRecognizerService recognizer,
            IMysteryService mystery,
            String defaultFileName = null,
            Int32 maxSaveAttempts = 3
        )
        {
            this.resizer    = resizer ?? throw new ArgumentNullException( nameof(resizer) );
            this.saver      = saver   ?? throw new ArgumentNullException( nameof(saver) );
            this.recognizer = recognizer ?? throw new ArgumentNullException( nameof(recognizer) );
            this.mystery = mystery ?? throw new ArgumentNullException( nameof(mystery) );
        }
    }
