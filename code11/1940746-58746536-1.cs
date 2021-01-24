    [Test]
    public void TestNormalization()
    {
        MeasuredValues myMeasuredValues = new MeasuredValues();
        
        ...
        // run the routine and pass the assert as callback
        TestRoutineRunner.Instance.TestRoutine(
            myMeasuredValues.Normalize(), 
            // for example as lambda expression
            () =>
            {
                // Assert here
            }
        );
    }
