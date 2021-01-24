    private static void TriggerAlarm()
    {
        TimeSpan alarmTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
        if (dict.TryGetValue(alarmTime, out string alarmFile))
        {
            using (SoundPlayer player = new SoundPlayer(alarmFile))
            {
                player.Play();
            }
        }
        else
        {
            //this alarm time is not found in the dictionary, 
            //therefore, no alarm should be played at this time (e.g. 16:05:00)
        }
    }
