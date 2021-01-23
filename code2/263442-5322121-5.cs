    private Process speechProcess;
    private void StartButtonClicked(object sender, EventArgs e)
    {
        // TODO: consider what you want to happen if there's already
        // a process running
        TextToSpeech obj = new TextToSpeech();
        speechProcess = obj.Speak();
    }
    private void StopButtonClicked(object sender, EventArgs e)
    {
        // Possibly change the UI so that the button will be disabled
        // when there's no process running
        if (speechProcess == null)
        {
            return;
        }
        speechProcess.Kill();
        speechProcess = null;
    }
