    static public void StopAll(Dictionary<string, DispatcherTimer> timerDict)
    {
        foreach(var timer in timerDict.Values) timer.Stop();
        timerDict.Clear();
    }
    static public void StopTimer(string TimerName, Dictionary<string, DispatcherTimer> timerDict)
    {
        if (timerDict.ContainsKey(TimerName)
        {
            timerDict[TimerName].Stop();
            timerDict.Remove(TimerName);
        }        
    }
