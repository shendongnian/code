    void LongRunningOperation(Action<float> progress)
    {
        for (int i = 0; i < lotsOfIterations; ++i)
        {
            SlowCalculation();
            progress(((float)i / lotsOfIterations) * 100);
        }
    }
