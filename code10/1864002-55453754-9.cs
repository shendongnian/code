    private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
    void playSound(string ss)
    {
        if(clips.ContainsKey(ss) && clip[ss] != null)
        {
            clipTarget = clips[ss];
        else
        {
            clip = (AudioClip)Resources.Load(ss);
            if(clipTarget == null) 
            {
                Debug.LogError("Couldn't get clip for " + ss, this);
                return;
            }
            clips.Add(ss, clipTarget);
        }
        soundTarget.clip = clipTarget;
        soundTarget.Play();
    }
