    public bool IsButtonEnabled
    {
      get {
        return !String.IsNullOrEmpty(entry1) &&
               !String.IsNullOrEmpty(entry2) &&
               // repeat for all Entries
      }
    }
