    public static void Update()
            {
                if (_sheduledSounds != null && _sheduledSounds.Count > 1)
                {
                    if (_sheduledSounds.Peek().State == SoundState.Stopped)
                    {
                        _sheduledSounds.Dequeue();
                        _sheduledSounds.Peek().Play();
                    }
                }
            }
