    defaultDevice.AudioEndpointVolume.OnVolumeNotification += new AudioEndpointVolumeNotificationDelegate(
        AudioEndpointVolume_OnVolumeNotification);
    // .. snip ..
    void AudioEndpointVolume_OnVolumeNotification(AudioVolumeNotificationData data)
    {
        Console.WriteLine("New Volume {0}", data.MasterVolume);
        Console.WriteLine("Muted      {0}", data.Muted);
    }
