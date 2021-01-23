    // Play Audio File and allow stop
            if (new Rectangle(rV.X, rV.Y, rect.Width, rect.Height).Contains(mosX, mosY) && mouseClick)
            {
                if (driversmeeting.State != SoundState.Playing && !globalAudioPlaying)
                {
                    globalAudioPlaying = true;
                    driversmeeting.Play();
                }
                else if (driversmeeting.State == SoundState.Playing)
                {
                    driversmeeting.Stop();
                    globalAudioPlaying = false;
                }
            }
