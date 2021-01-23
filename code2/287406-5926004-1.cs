    public void Say(string say)
    {
        SpeechSynthesizer talker = new SpeechSynthesizer();
        talker.Speak(say);
    }
