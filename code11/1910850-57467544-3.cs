    if(onSpeedChangeDelegate != null)
    {
        onSpeedChangeDelegate(2f); // This invokes the delegate
        yield return new WaitForSeconds(5); // suspend the process for 5 seconds
        onSpeedChangeDelegate(10f); // 5 seconds later, set speed back
    }
