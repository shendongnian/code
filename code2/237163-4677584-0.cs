    SpVoice oVoice = new SpVoice();
    oVoice.Voice = oVoice.GetVoices("","").Item(0); // 0 indicating what kind of speaker you want
    oVoice.Volume = 50;
    oVoice.Speak("hello world", SpeechVoiceSpeakFlags.SVSFDefault);
    oVoice = null;
