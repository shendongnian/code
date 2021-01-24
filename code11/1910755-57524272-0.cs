    public void SpeakTheText(string text)
    {  
    	// Initialize a new instance of the speech synthesizer.  
    	using (SpeechSynthesizer synth = new SpeechSynthesizer())  
    	using (MemoryStream streamAudio = new MemoryStream())  
    	{  
    		// Create a SoundPlayer instance to play the output audio file.  
    		System.Media.SoundPlayer m_SoundPlayer = new System.Media.SoundPlayer();  
    		// Set voice to male
    		synth.SelectVoiceByHints(VoiceGender.Male);
    		// Configure the synthesizer to output to an audio stream.  
    		synth.SetOutputToWaveStream(streamAudio);  
    
    		// Speak a phrase.  
    		synth.Speak(text);  
    		streamAudio.Position = 0;  
    		m_SoundPlayer.Stream = streamAudio;  
    		m_SoundPlayer.Play();  
    
    		// Set the synthesizer output to null to release the stream.   
    		synth.SetOutputToNull();  
    
    		// Insert code to persist or process the stream contents here.  
    	}
    }
