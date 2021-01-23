    /// <summary>
    /// Wait no longer than @waitNoLongerThanMillis for @thatWhatWeAreWaitingFor to return true.
    /// Tests every second for the 
    /// </summary>
    /// <param name="thatWhatWeAreWaitingFor">Function that when evaluated returns true if the state we are waiting for has been reached.</param>
    /// <param name="waitNoLongerThanMillis">Max time to wait in milliseconds</param>
    /// <param name="checkEveryMillis">How often to check for @thatWhatWeAreWaitingFor</param>
    /// <returns></returns>
    private bool WaitFor(Func<bool> thatWhatWeAreWaitingFor, int checkEveryMillis, int waitNoLongerThanMillis)
    {
        var waitedFor = 0;
        while (waitedFor < waitNoLongerThanMillis)
        {
            if (thatWhatWeAreWaitingFor()) return true;
    
            Console.WriteLine("Waiting another {0}ms for a situation to occur.  Giving up in {1}ms ...", checkEveryMillis, (waitNoLongerThanMillis - waitedFor));
            Thread.Sleep(checkEveryMillis);
            waitedFor += checkEveryMillis;
        }
        return false;
    }
