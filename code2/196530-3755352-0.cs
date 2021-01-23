    public bool Archived {
      get {
        return (f.Attributes & FileAttributes.Archive) != 0;
      }
      set {
        if (value) {
          if (!this.Archived) {
            f.Attributes |= FileAttributes.Archive;
          }
        } else {
          if (this.Archived) {
            f.Attributes &= ~FileAttributes.Archive;
          }
        }
      }
    }
