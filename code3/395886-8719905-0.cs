    public ReadOnlyCollection<Character> Characters {
      get {
        lock (this.characters.SyncRoot) { return this.characters.AsReadOnly(); }
      }
    }
