    public float recordingFrames;
    public float playbackFrames;
    public List<float> clickFrames;
    public bool recording;
    public bool playing;
    public int nextClickFrameIndex = 0;
    
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
