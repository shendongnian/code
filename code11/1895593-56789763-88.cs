    public void ThrowIfCancellationRequested()
    {
      if (IsCancellationRequested) 
        ThrowOperationCanceledException();
    }
 
    // Throws an OCE; separated out to enable better inlining of ThrowIfCancellationRequested
    private void ThrowOperationCanceledException()
    {
      throw new OperationCanceledException(Environment.GetResourceString("OperationCanceled"), this);
    }
