    public AudioSource source;
    IEnumerator PlayTTS()
    {
        using (var wr = new UnityWebRequestMultimedia.GetAudioClip(
            "https://example.com/tts?text=Sample%20Text&voice=Male",
            AudioType.OGGVORBIS)
        )
        {
            ((DownloadHandlerAudioClip)wr.downloadHandler).streamAudio = true;
            wr.Send();
            while(!wr.isNetworkError && wr.downloadedBytes <= someThreshold)
            {
                yield return null;
            }
            if (wr.isNetworkError)
            {
                Debug.LogWarning(wr.error);
            }
            else
            {
                // Here I'm not sure if you would use
                source.PlayOneShot(DownloadHandlerAudioClip.GetContent(wr)); 
                // or rather
                source.PlayOneShot((DownloadHandlerAudioClip)wr.downloadHandler).audioClip);     
            }
        }
    }
