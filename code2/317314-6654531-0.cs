    [DebuggerStepThrough]
    public void SomeMethod()
    {
        HitTestResult result;
        try
        {
            result = this.HitTest(e.X, e.Y, ChartElementType.DataPoint);
        }
        catch (Exception e)
        {
            //This happens, we don't care!
        }
    }
