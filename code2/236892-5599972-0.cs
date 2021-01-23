    public byte[] TextToBytes(string textToSpeak)
    {
        byte[] byteArr = null;
        var t = new System.Threading.Thread(() =>
        {
            SpeechSynthesizer ss = new SpeechSynthesizer();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                ss.SetOutputToWaveStream(memoryStream);
                ss.Speak(textToSpeak);
                byteArr = memoryStream.ToArray();
            }
        });
        t.Start();
        t.Join();
        return byteArr;
    }
