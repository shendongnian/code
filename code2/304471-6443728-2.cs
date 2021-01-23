    private void button1_Click(object sender, EventArgs e)
    {
        var cu = CultureInfo.GetCultureInfo("zh-CN");
        SpeechSynthesizer sp = new SpeechSynthesizer();
        var voices = sp.GetInstalledVoices(cu);
        sp.SelectVoice(voices[0].VoiceInfo.Name);
        string s = "<?xml version=\"1.0\"?> <speak version=\"1.0\" xml:lang=\"zh-CN\"><phoneme ph=\"ang 1 zang 1\">变</phoneme></speak>";
        sp.SpeakSsml(s);
    }
