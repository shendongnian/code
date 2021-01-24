        public IActionResult SomeView()
        {
            TextToSpeech();
            return View();
        }
    public void TextToSpeech()
        {
            // Instantiate a client
            TextToSpeechClient client = TextToSpeechClient.Create();
            // Set the text input to be synthesized.
            SynthesisInput input = new SynthesisInput
            {
                Text = "Hello, World!"
            };
            // Build the voice request, select the language code ("en-US"),
            // and the SSML voice gender ("neutral").
            VoiceSelectionParams voice = new VoiceSelectionParams
            {
                LanguageCode = "en-US",
                SsmlGender = SsmlVoiceGender.Neutral
            };
            // Select the type of audio file you want returned.
            AudioConfig config = new AudioConfig
            {
                AudioEncoding = AudioEncoding.Mp3
            };
            // Perform the Text-to-Speech request, passing the text input
            // with the selected voice parameters and audio file type
            var response = client.SynthesizeSpeech(new SynthesizeSpeechRequest
            {
                Input = input,
                Voice = voice,
                AudioConfig = config
            });
            //// Write the binary AudioContent of the response to an MP3 file.
            //using (System.IO.Stream output = File.Create("sample.mp3"))
            //{
            //    response.AudioContent.WriteTo(output);
            //    Console.WriteLine($"Audio content written to file 'sample.mp3'");
            //}
        }
