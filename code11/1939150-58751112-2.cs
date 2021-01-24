    class Program
    {
        private static ManualResetEvent _done;
        static void Main(string[] args)
        {
            _done = new ManualResetEvent(false);
            using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new CultureInfo("en-US")))
            {
                recognizer.LoadGrammar(new DictationGrammar());
                recognizer.SpeechRecognized += RecognizedSpeech;
                recognizer.SetInputToDefaultAudioDevice();
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                _done.WaitOne();
            }
        }
        private static void RecognizedSpeech(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.Contains("exit"))
            {
                _done.Set();
            }
            Console.WriteLine(e.Result.Text);
        }
    }
