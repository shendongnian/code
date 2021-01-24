    public partial class Form1 : Form
    {
        private SpeechRecognizer recognizer; // <-- instance variable
        public async Task SpeechContinuousRecognitionAsync()
        {
            var config = SpeechConfig.FromSubscription("api key", "westus");
            // Create a speech recognizer from microphone.
            recognizer = new SpeechRecognizer(config);
            recognizer.Recognizing += (s, e) =>
            {
                // ...
            };
            // ... rest of initialization
        }
    }
