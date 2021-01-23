    List lst = new List();
    foreach (InstalledVoice voice in spsynthesizer.GetInstalledVoices())
    {
        lst.Items.Add(voice.VoiceInfo);
    }
    spsynthesizer.SelectVoice(lstVoice[0].Name);
