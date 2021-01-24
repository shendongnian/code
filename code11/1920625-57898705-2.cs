    public void ButtonClick()
    {
        if (waitingForSpeak) return;
        waitingForSpeak = true;
        // Creates an instance of a speech config with specified subscription
        // key and service region.
        // Replace with your own subscription key and service region (e.g., "westus").
        SpeechConfig config = SpeechConfig.FromSubscription("[redacted]", "westus");
        // Creates a speech synthesizer.
        // Make sure to dispose the synthesizer after use!       
        SpeechSynthesizer synthesizer = new SpeechSynthesizer(config, null));
        // Starts speech synthesis, and returns after a single utterance is synthesized.
        Task<SpeechSynthesisResult> task = synthesizer.SpeakTextAsync(inputField.text);
        StartCoroutine(CheckSynthesizer(task, config, synthesizer));
    }
    
    private IEnumerator CheckSynthesizer(Task<SpeechSynthesisResult> task, 
            SpeechConfig config, 
            SpeechSynthesizer synthesizer)
    {
        yield return new WaitUntil(() => task.IsCompleted());
        var result = task.Result;
        // Checks result.
        string newMessage = string.Empty;
        if (result.Reason == ResultReason.SynthesizingAudioCompleted)
        {
            // Since native playback is not yet supported on Unity yet (currently
            // only supported on Windows/Linux Desktop),
            // use the Unity API to play audio here as a short term solution.
            // Native playback support will be added in the future release.
            var sampleCount = result.AudioData.Length / 2;
            var audioData = new float[sampleCount];
            for (var i = 0; i < sampleCount; ++i)
            {
                audioData[i] = (short)(result.AudioData[i * 2 + 1] << 8 
                        | result.AudioData[i * 2]) / 32768.0F;
            }
            // The default output audio format is 16K 16bit mono
            var audioClip = AudioClip.Create("SynthesizedAudio", sampleCount, 
                    1, 16000, false);
            audioClip.SetData(audioData, 0);
            audioSource.clip = audioClip;
            audioSource.Play();
            newMessage = "Speech synthesis succeeded!";
        }
        else if (result.Reason == ResultReason.Canceled)
        {
            var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
            newMessage = $"CANCELED:\nReason=[{cancellation.Reason}]\n"+
                         $"ErrorDetails=[{cancellation.ErrorDetails}]\n"+"
                         "Did you update the subscription info?";
        }
   
        message = newMessage;
        waitingForSpeak = false;
        synthesizer.Dispose();
    }
    void Start()
    {
        if (inputField == null)
        {
            message = "inputField property is null! Assign a UI InputField element to it.";
            UnityEngine.Debug.LogError(message);
        }
        else if (speakButton == null)
        {
            message = "speakButton property is null! Assign a UI Button to it.";
            UnityEngine.Debug.LogError(message);
        }
        else
        {
            // Continue with normal initialization, Text, InputField and Button 
            // objects are present.
            inputField.text = "Enter text you wish spoken here.";
            message = "Click button to synthesize speech";
            speakButton.onClick.AddListener(ButtonClick);
            //ButtonClick();
        }
    }
