    static object AsyncRecognizeGcs(string storageUri)
    {
        var speech = SpeechClient.Create();
        var longOperation = speech.LongRunningRecognize(new RecognitionConfig()
        {
            Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
            SampleRateHertz = 16000,
            LanguageCode = "en",
        }, RecognitionAudio.FromStorageUri(storageUri));
        longOperation = longOperation.PollUntilCompleted();
        var response = longOperation.Result;
        foreach (var result in response.Results)
        {
            foreach (var alternative in result.Alternatives)
            {
                Console.WriteLine($"Transcript: { alternative.Transcript}");
            }
        }
        return 0;
    }
