    public float recordingFrames;
    public float playbackFrames;
    public List<float> clickFrames;
    public bool recording;
    public bool playing;
    public int nextClickFrameIndex;
    public void BeginPlayback()
    {
        nextClickFrameIndex = 0;
        playback = true;
    }
 
    public void InputRecordPlayback()
    {
        if (recording)
        {
            recordingFrames += Time.deltaTime;
            if (Input.GetMouseButton(0))
            {
                clickFrames.Add(recordingFrames);
            }
        }
    
        if (playback)
        {
            playbackFrames += Time.deltaTime;
            // loop while you have clicks left in the replay
            // AND you have clicks to playback since the last frame
            while (
                    nextClickFrameIndex < playBackFrames.Count 
                    && clickFrames[nextClickFrameIndex] <= playbackFrames 
                    )
            {
                nextClickFrameIndex++;
                Debug.Log("hello!");
            }
        }
    }
