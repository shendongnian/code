    using System.Linq;
    ...
    private AudioClip GetRandomClip()
    {
        // This returns only those clips that are not the currenty played one
        var filteredClips = clips.Where(c => c != audioSource.clip).ToArray();
        return filteredClips[Random.Range(0, filteredClips.Length)];
    }
    
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            var newTitle = GetRandomClip();
            audioSource.clip = newTitle;
            audioSource.Play();
        }
    }
