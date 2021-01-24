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
   
            Task copyTask = Task.Factory.StartNew( () => 
            {
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
            });
            yield return new WaitUntil(() => copyTask.IsCompleted());
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
