    StorageFolder folder = KnownFolders.VideosLibrary;
    StorageFile file = await folder.CreateFileAsync("MyVideo.mp3",CreationCollisionOption.ReplaceExisting);
    if (file != null)
    {
        try
        {
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Hello World");
    
            using (var reader = new DataReader(stream))
            {
                await reader.LoadAsync((uint)stream.Size);
                IBuffer buffer = reader.ReadBuffer((uint)stream.Size);
                await FileIO.WriteBufferAsync(file, buffer);
            }
        }
        catch {}
    }
