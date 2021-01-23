    using (var audioSource = new KinectAudioSource())
    {
        audioSource.FeatureMode = true;
        audioSource.AutomaticGainControl = false;
        audioSource.SystemMode = SystemMode.OptibeamArrayOnly;
    
        System.Speech.Recognition.RecognizerInfo ri = GetKinectRecognizer();
        var speechRecognitionEngine = new SpeechRecognitionEngine(ri.Id);
    
        speechRecognitionEngine.LoadGrammar(new DictationGrammar());
        speechRecognitionEngine.SpeechRecognized += (s, args) => MessageBox.Show(args.Result.Text);
    
        using (var s = audioSource.Start())
        {
            speechRecognitionEngine.SetInputToAudioStream(s, new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
            speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }
    }
