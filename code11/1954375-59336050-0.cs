    public void SwapBool()
    {
        observableBool = !observableBool;
        foreach (observable in observers)
        {
            observable.OnNext(observableBool);
        }
    }
