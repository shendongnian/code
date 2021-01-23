    void Do()
    {
        string [] splitSentences = new [] {"bye", "hello"};
        for (int i = 0; i < splitSentences.Length; i++)
        {
            HighLight(splitSentences[i], this);
            sound_object.Speak(splitSentences[i]);
        }
    }
    void HighLight(string str, Control webBrowser)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action<string>(s, c => HighLight(s, c)));
        }
            
        // Highlight code here
    }
