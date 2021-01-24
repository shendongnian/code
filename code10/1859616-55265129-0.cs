    private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        this.ProcessSpeechRecognition(e.Result);
    }
    public void ProcessSpeechRecognition(RecognitionResult result)
    {
        // your logic here
    }
