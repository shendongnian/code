    using System.Linq;
    ...
    private AudioClip GetRandomClip()
    {
        // This returns only those clips that are not the currenty played one
        var filteredCips = clips.Where(c => c != audioSource.clip).ToArray();
        return filteredCips[Random.Range(0, filteredCips.Length)];
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
