    if (Settings.mode.IsPractice() && App.practiceRunning != true)
    {
        if (await IsPractice()) {
            // Do something here
        }
    }
    private async Task<bool> IsPractice()
    {
        return true;
    }
