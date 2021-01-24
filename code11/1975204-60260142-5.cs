    CancellationTokenSource cSource;
    private async void EmoStart_Click_1(object sender, EventArgs e)
    {
        EmoStart.Enabled = false;
        cSource = new CancellationTokenSource();
        await Task.Factory.StartNew(() => Loop(cSource.Token));
        EmoStart.Enabled = true;
    }
    private void Loop(CancellationToken cToken)
    {
        string imageFilePath = "C:\\Users\\Administrator\\source\\repos\\FaceDetection\\FaceDetection\\test3.jpg";
        while (true)
        {
            if (cToken.IsCancellationRequested)
                break;
            // otherwise do your stuff
        }
        // some clean up here if necessary
    }
    private async void VoiceStart_Click_2(object sender, EventArgs e)
    {
        VoiceStart.Enabled = false;
        cSource.Cancel();
        VoiceStart.Enabled = true;
    }
