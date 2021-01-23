    object syncRootIteration = new object();
    long iterationCount = 0;
    long iterationTimeMs = 0;
    public void IncrementIterationCount(long timeTook)
    {
        lock (syncRootIteration)
        {
            iterationCount++;
            iterationTimeMs = timeTook;
        }
    }
    public long GetIterationAvgTimeMs()
    {
        long result = 0;
        //if read without lock the result might not be accurate
        lock (syncRootIteration)
        {
            if (this.iterationCount > 0)
            {
                result = this.iterationTimeMs / this.iterationCount;
            }
        }
        return result;
    }
