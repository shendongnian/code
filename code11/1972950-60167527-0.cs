    //Side node: async void is a bad idea except event handlers
    private async void VoiceStart_Click_2(object sender, EventArgs e)
    {
        string command = await Voice.RecognizeSpeechAsync();
        VoiceBox.Text = command;
    }
    
