    private WatchedVariable<string> state;
    public void WaitForBlob()
    {
      string value = state.Value;
      while (value != "Blob")
      {
        value = state.WaitForChange(value);
      }
    }
