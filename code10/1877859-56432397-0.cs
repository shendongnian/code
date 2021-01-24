    Camera cam;
    bool bPause = false;
    void Update()
    {
        //install 'Oculus Integration' for this to work
        bool bPauseNow = !(OVRManager.hasInputFocus && OVRManager.hasVrFocus);
        //pause state change
        if (Camera.main != null) cam = Camera.main;
        if (bPause != bPauseNow)
        {
            bPause = bPauseNow;
            if (bPauseNow)
            {
                Time.timeScale = 0.0f; //stops FixedUpdate
                //Update keeps running, but 
                // rendering must also be paused to pass vrc
                cam.enabled = false;
            }
            else
            {
                Time.timeScale = 1.0f;
                //
                cam.enabled = true;
            }
        }
        //...
    }
